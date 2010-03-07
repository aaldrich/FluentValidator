using System;
using System.Collections.Generic;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public partial class DateValidationBuilder<T> where T : class
    {
        public IDatePartValidationBuilder<T> should_be()
        {
            return this;
        }

        public IDatePartValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }
    }
}