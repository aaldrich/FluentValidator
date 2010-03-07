using System;
using System.Linq;
using Validation.Helpers;
using Validation.Helpers.Generics;
using Validation.Mapping.ValidationMappers;
using Validation.Registry;

namespace Validation.Validation
{
    public static class Validator
    {
        static readonly IGenericListFactory generic_list_factory;
        static readonly IGenericValidatorFactory generic_validator_factory;

        static Validator()
        {
            generic_list_factory = new GenericListFactory();
            generic_validator_factory = new GenericValidatorFactory();
        }

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

                bool result = validate_property_map(instance, property, validators_instance);
                if (!result) return false;
            }

            return true;
        }

        /// <summary>
        /// Validates a ValidationMap for the specified property.
        /// Example: A Person has a Address property. This method
        /// is responsible for validating the Address.
        /// </summary>
        /// <typeparam name="T">The Generic Type T passed in</typeparam>
        /// <param name="instance">An instance of the Generic Type ie. Person</param>
        /// <param name="property">A TypeInfo that stores things such
        ///  as PropertyInfo ie. Address Property</param>
        /// <param name="validators_instance">The validators property
        ///  on the cooresponding ValidationMap instance ie. PersonMap.validators</param>
        /// <returns>true if all validators passed, false if not.</returns>
        static bool validate_property_map<T>(T instance, TypeInfo property, object validators_instance)
        {
            var value = ReflectionHelper.get_property_value(instance, property.property_info.Name);

            var generic_validator = generic_validator_factory
                .create(property.type.AssemblyQualifiedName);            
            
            var generic_list = generic_list_factory
                .create(generic_validator.generic_type,validators_instance);

            for (int i = 0; i < generic_list.count; i++)
            {
                var validator = generic_list.items[i];
                var result = generic_validator.Validate(validator, value);
                if (!result)
                    return false;
            }

            return true;
        }

        static object get_property_validators(TypeInfo property, object property_validation_map)
        {
            var validators = 
                ReflectionHelper.create_generic_ValidationMap(property.type.AssemblyQualifiedName)
                .GetProperty("validators");

            return validators.GetValue(property_validation_map, null);
        }

        static bool validate_instance<T>(T instance) where T : class
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