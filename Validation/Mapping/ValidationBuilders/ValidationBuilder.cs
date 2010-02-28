using System.Collections.Generic;
using Validation.Helpers;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class ValidationBuilder<T> : IObjectHidingHelper
    {
        protected internal readonly IList<IValidator<T>> validators;

        public ValidationBuilder(IList<IValidator<T>> validators)
        {
            this.validators = validators;
        }
    }
}