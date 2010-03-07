using System;

namespace Validation.Validation.Validators
{
    public abstract class ValidatorBase<T>
    {
        public string failure_message { get; set; }
        public Action<T> execute_upon_failure { get; set; }
    }
}