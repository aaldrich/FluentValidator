using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Validation.Helpers;
using Validation.Helpers.Generics;
using Validation.Mapping.ValidationBuilders;
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

                object validators_instance = get_validators_property(property, property_validation_map);

                bool should_ignore_validator = should_ignore_validator<T>(instance,property);
                if (!should_ignore_validator)
                    validation_result = validate_property_map(instance, property, validators_instance, validation_result);
            }

            return validation_result;
        }

        static bool should_ignore_validator<T>(T instance, TypeInfo property) where T : class
        {
            var validation_map = get_validation_map(instance);

            var ignore_validator = new IgnoreValidator(typeof(T).AssemblyQualifiedName, property.property_info.Name, property.type.AssemblyQualifiedName);
            return validation_map.ignore_validators.Contains(ignore_validator);
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

        /// <summary>
        /// Gets the validators property from the genericly created ValidationMap.
        /// Only used for complex object properties of the main class.
        /// </summary>
        /// <param name="property">The TypeInfo of the property</param>
        /// <param name="property_instance">The instance of the validation map</param>
        /// <returns></returns>
        static object get_validators_property(TypeInfo property, object property_instance)
        {
            var validators = 
                ReflectionHelper.create_generic_ValidationMap(property.type.AssemblyQualifiedName)
                .GetProperty("validators");

            return validators.GetValue(property_instance, null);
        }

        /// <summary>
        /// Validates the main instance given. This does not include complex object
        /// properties of the class. For instance if Validate(Person) is called
        /// this method would validate the Person but not their Address.
        /// </summary>
        /// <typeparam name="T">The Generic Type to validate</typeparam>
        /// <param name="instance">The Instance of the object to validate</param>
        /// <returns>Result with success and reasons for failure if validation fails.</returns>
        static ValidationResult validate_instance<T>(T instance) where T : class
        {
            var validation_result = new ValidationResult();

            ValidationMap<T> validation_map = get_validation_map(instance);

            foreach (var validator in validation_map.validators)
            {
                if (!validator.Validate(instance))
                    validation_result.validator_failures.Add(new ValidatorResult { failure_message = validator.failure_message, successful = false });
            }

            return validation_result;
        }

        static ValidationMap<T> get_validation_map<T>(T instance) where T : class
        {
            var map = ValidationRegistry.validation_maps[instance.GetType().AssemblyQualifiedName];
            var validation_map = map as ValidationMap<T>;

            if (validation_map == null)
                throw new NullReferenceException(
                    String.Format("No validation map stored in registry for {0}",instance.GetType().AssemblyQualifiedName));

            return validation_map;
        }

        public static void SelfValidate()
        {
            ValidationRegistry.IsValid();
        }
    }
}