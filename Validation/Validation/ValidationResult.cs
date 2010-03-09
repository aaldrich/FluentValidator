using System.Collections.Generic;

namespace Validation.Validation
{
    public class ValidationResult
    {
        public bool successful
        {
            get
            {
                return validator_failures.Count == 0;
            }
        }

        public IList<ValidatorResult> validator_failures { get; protected set; }

        public ValidationResult()
        {
            validator_failures = new List<ValidatorResult>();
        }
    }
}