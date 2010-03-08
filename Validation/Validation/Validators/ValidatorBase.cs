using System;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public class ValidatorBase<T>
    {
        public string failure_message
        {
            get{return failure_message_strategy.get_failure_message(); } 
        }

        public Action<T> execute_upon_failure { get; set; }
        public IFailureMessageStrategy failure_message_strategy { get; set; }

        public ValidatorBase()
        {
            failure_message_strategy = new CustomFailureMessageStrategy(String.Empty);
        }
    }
}