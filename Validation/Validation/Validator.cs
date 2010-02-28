using System;
using Validation.Helpers;
using Validation.Registry;

namespace Validation.Validation
{
    public static class Validator
    {
        public static bool Validate<T>(T instance) where T : class
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            if (!validate_type(instance)) 
                return false;

            if (!validate_property_classes<T>())
                return false;

            return true;
        }

        static bool validate_property_classes<T>() where T : class
        {
            var properties = ReflectionHelper.get_class_properties_for<T>();
            foreach (var property in properties)
            {
                var type = Type.GetType(property);
                if (!validate_type(type))
                    return false;
            }
            return true;
        }

        static bool validate_type<TType>(TType instance)
        {
            var validation_map = ValidationRegistry.GetMapFor<TType>();

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