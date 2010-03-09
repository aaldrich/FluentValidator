using System;
using System.Collections;
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

        public static ValidationResult Validate<T>(T instance) where T : class
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            var validation_result = validate_instance(instance);

            var properties = ReflectionHelper.get_class_properties_for<T>()
                .Where(x => ValidationRegistry.validation_maps.ContainsKey(x.type.AssemblyQualifiedName));

            foreach (var property in properties)
            {
                var property_validation_map = ValidationRegistry.validation_maps[property.type.AssemblyQualifiedName];

                object validators_instance = get_property_validators(property, property_validation_map);

                validation_result = validate_property_map(instance, property, validators_instance, validation_result);
            }

            return validation_result;
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
        /// <param name="validators_instance">The validators property</param>
        /// <param name="validation_result">The validation result that this method should add validation failures to.</param>
        ///  on the cooresponding ValidationMap instance ie. PersonMap.validators</param>
        /// <returns>Validation Result adding any new validator failures to the list.</returns>
        static ValidationResult validate_property_map<T>(T instance, TypeInfo property, object validators_instance, ValidationResult validation_result)
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
                    validation_result.validator_failures.Add(
                        new ValidatorResult { failure_message = generic_validator.failure_message(validator), successful = false });
            }

            return validation_result;
        }

        static object get_property_validators(TypeInfo property, object property_validation_map)
        {
            var validators = 
                ReflectionHelper.create_generic_ValidationMap(property.type.AssemblyQualifiedName)
                .GetProperty("validators");

            return validators.GetValue(property_validation_map, null);
        }

        static ValidationResult validate_instance<T>(T instance) where T : class
        {
            var validation_result = new ValidationResult();

            var map = ValidationRegistry.validation_maps[instance.GetType().AssemblyQualifiedName];
            var validation_map = map as ValidationMap<T>;

            if (validation_map == null)
                throw new NullReferenceException(
                    String.Format("No validation map stored in registry for {0}",instance.GetType().AssemblyQualifiedName));

            foreach (var validator in validation_map.validators)
            {
                if (!validator.Validate(instance))
                    validation_result.validator_failures.Add(new ValidatorResult { failure_message = validator.failure_message, successful = false });
            }

            return validation_result;
        }

        public static void SelfValidate()
        {
            ValidationRegistry.IsValid();
        }
    }
}