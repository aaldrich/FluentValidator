using System;

namespace Validation.Validation.Validators
{
    /// <summary>
    /// Wraps a Validator with a not. This will allow any IValidator to be used.
    /// </summary>
    public class NotValidatorWrapper<T,TValidator> : ValidatorBase<T>, IValidator<T>
        where TValidator : IValidator<T>
        where T : class 
    {
        readonly TValidator validator;

        public NotValidatorWrapper(TValidator validator)
        {
            this.validator = validator;
        }

        public bool Validate(T value)
        {
            if (null == value)
                return false;

            var result = !validator.Validate(value);

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result;
        }
    }
}