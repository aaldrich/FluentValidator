namespace Validation.Validation.Validators
{
    public interface IValidator<T> 
    {
        bool Validate(T value);
    }
}