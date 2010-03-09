using System;
using System.Reflection;
using Validation.Validation.Failures;

namespace Validation.Helpers.Generics
{
    public class GenericValidator
    {
        public Type generic_type { get; internal set;}
        readonly MethodInfo validate_method;
        readonly PropertyInfo failure_message_strategy;

        public GenericValidator(Type generic_validator, MethodInfo validate_method, PropertyInfo failure_message_strategy)
        {
            this.generic_type = generic_validator;
            this.validate_method = validate_method;
            this.failure_message_strategy = failure_message_strategy;
        }

        public bool Validate(object validator_instance, object value)
        {
            return (bool)validate_method.Invoke(validator_instance, new[] { value });
        }

        public string failure_message(object validator_instance)
        {
            var strategy =  (IFailureMessageStrategy)failure_message_strategy.GetValue(validator_instance, null);
            return strategy.get_failure_message();
        }
    }
}