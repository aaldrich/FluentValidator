using System;
using Validation.Registry;

namespace Validation.Validation
{
    public static class Validator
    {
        public static bool Validate<T>(T instance) where T : class
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            var validation_map = ValidationRegistry.GetMapFor<T>();

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