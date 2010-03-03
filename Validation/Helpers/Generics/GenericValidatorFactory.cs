using System;
using Validation.Validation.Validators;

namespace Validation.Helpers.Generics
{
    public class GenericValidatorFactory: IGenericValidatorFactory
    {
        public GenericValidator create(string validator_assembly_qualified_name)
        {
            var generic_validator = typeof(IValidator<>)
                .MakeGenericType(Type.GetType(validator_assembly_qualified_name));
            
            var method = generic_validator.GetMethod("Validate");

            return new GenericValidator(generic_validator,method);
        }
    }

    public interface IGenericValidatorFactory
    {
        GenericValidator create(string validator_assembly_qualified_name);
    }
}