using System.Collections.Generic;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    /// <summary>
    /// Allows a class to wrap validators with not logic. Provides base methods
    /// to help facilitate not wrapping.
    /// </summary>
    /// <typeparam name="T">The Validation Type</typeparam>
    public class CanWrapWithNotValidationBuilder<T> : ValidationBuilder<T> where T : class
    {
        protected bool should_wrap_with_not {get;set;}

        protected CanWrapWithNotValidationBuilder(IList<IValidator<T>> validators) : base(validators)
        {
        }

        protected NotValidatorWrapper<T, TValidator> wrap_with_not<TValidator>(TValidator validator) where TValidator : IValidator<T>
        {
            return new NotValidatorWrapper<T, TValidator>(validator);
        }

        protected void add_validator_with_not_wrapper_if_needed<TValidator>(TValidator validator_to_wrap) where TValidator : IValidator<T>
        {
            if (should_wrap_with_not)
                validators.Add(wrap_with_not(validator_to_wrap));
            else
            {
                validators.Add(validator_to_wrap);
            }
        }
                    

    }
}