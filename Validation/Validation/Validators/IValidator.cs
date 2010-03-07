using System;

namespace Validation.Validation.Validators
{
    public interface IValidator<T> 
    {
        bool Validate(T value);
        string failure_message {get;set;}
        Action<T> execute_upon_failure { get; set; }
    }
}