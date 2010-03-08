using System;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public interface IValidator<T> 
    {
        bool Validate(T value);
        string failure_message {get;}
        Action<T> execute_upon_failure { get; set; }
        IFailureMessageStrategy failure_message_strategy { get; set; }
    }
}