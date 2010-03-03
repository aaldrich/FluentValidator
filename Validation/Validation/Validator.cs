using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validation.Helpers;
using Validation.Mapping.ValidationMappers;
using Validation.Registry;
using Validation.Validation.Validators;

namespace Validation.Validation
{
    public static class Validator
    {
        public static bool Validate<T>(T instance) where T : class
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            if (!validate_instance(instance)) return false;

            var properties = ReflectionHelper.get_class_properties_for<T>()
                .Where(x => ValidationRegistry.validation_maps.ContainsKey(x.type.AssemblyQualifiedName));

            foreach (var property in properties)
            {
                var property_validation_map = ValidationRegistry.validation_maps[property.type.AssemblyQualifiedName];

                object validators_instance = get_property_validators(property, property_validation_map);

                bool worked = validate_property_map(instance, property, validators_instance);
                if (!worked) return false;
            }

            return true;
        }

        static bool validate_property_map<T>(T instance, TypeInfo property, object validators_instance)
        {
            var closed_validator = typeof(IValidator<>).MakeGenericType(Type.GetType(property.type.AssemblyQualifiedName));
            var closed_list = typeof(List<>).MakeGenericType(closed_validator);
            var count = (int)closed_list.GetMethod("get_Count").Invoke(validators_instance, null);

            for (int i = 0; i < count; i++)
            {
                var validator = closed_list.GetMethod("get_Item").Invoke(validators_instance, new object[] { i });
                var value = instance.GetType().GetProperty(property.property_info.Name).GetValue(instance, null);
                var method_template = closed_validator.GetMethod("Validate");
                var result = (bool)method_template.Invoke(validator, new []{ value });
                if (!result)
                    return false;
            }

            return true;
        }

        static object get_property_validators(TypeInfo property, object property_validation_map)
        {
            var validators_generic 
                = typeof(ValidationMap<>)
                    .MakeGenericType(Type.GetType(property.type.AssemblyQualifiedName))
                    .GetProperty("validators");

            return validators_generic.GetValue(property_validation_map, null);
        }

        static bool validate_instance<T>(T instance)
        {
            var map = ValidationRegistry.validation_maps[instance.GetType().AssemblyQualifiedName];
            var validation_map = map as ValidationMap<T>;

            if (validation_map == null)
                throw new NullReferenceException(
                    String.Format("No validation map stored in registry for {0}",instance.GetType().AssemblyQualifiedName));

            foreach (var validator in validation_map.validators)
            {
                if (!validator.Validate(instance))
                    return false;
            }

            return true;
        }

        public static void SelfValidate()
        {
            ValidationRegistry.IsValid();
        }
    }
}