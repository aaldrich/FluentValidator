using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public partial class DateValidationBuilder<T> : CanWrapWithNotValidationBuilder<T>,
                                                    IDateEntryValidationBuilder<T>,
                                                    IDatePartValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, DateTime>> expression;

        public DateValidationBuilder(Expression<Func<T,DateTime>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators) : base(validators,ignore_validators)
        {
            this.expression = expression;
        }
    }
}