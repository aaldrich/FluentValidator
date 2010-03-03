using System;

namespace Validation.Validation.Validators
{
    public interface IValidator<T> // : IValidator 
    {
        bool Validate(T value);
    }
    
    //public interface IValidator
    //{
    //    bool Validate(Type type, object value);

    //}
}