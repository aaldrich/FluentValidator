using System;

namespace Validation.Validation.Failures
{
    public class CustomFailureMessageStrategy : IFailureMessageStrategy
    {
        readonly string failure_message;

        public CustomFailureMessageStrategy(string failure_message)
        {
            this.failure_message = failure_message;
        }

        public string get_failure_message()
        {
            return failure_message ?? String.Empty;
        }
    }
}