using System;
using System.Reflection;

namespace Validation.Helpers.Generics
{
    public class GenericValidator
    {
        public Type generic_type { get; internal set;}
        readonly MethodInfo validate_method;

        public GenericValidator(Type generic_validator, MethodInfo validate_method)
        {
            this.generic_type = generic_validator;
            this.validate_method = validate_method;
        }

        public bool Validate(object validator_instance, object value)
        {
            return (bool)validate_method.Invoke(validator_instance, new[] { value });
        }
        
    }
}