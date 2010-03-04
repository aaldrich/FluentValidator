using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Date;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public DateTimeValidationBuilder<T> Map(Expression<Func<T, DateTime>> property)
        {
            return new DateTimeValidationBuilder<T>(property,validators);
        }
    }
}