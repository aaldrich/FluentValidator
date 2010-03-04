namespace Validation.Validation.Validators
{
    /// <summary>
    /// Wraps a Validator with a not. This will allow any IValidator to be used.
    /// </summary>
    public class NotValidatorWrapper<T,TValidator> : IValidator<T> where TValidator : IValidator<T>
    {
        readonly TValidator validator;

        public NotValidatorWrapper(TValidator validator)
        {
            this.validator = validator;
        }

        public bool Validate(T value)
        {
            return !validator.Validate(value);
        }
    }
}