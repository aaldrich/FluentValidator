using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Dates;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public IDateTimeEntryValidationBuilder<T> Map(Expression<Func<T, DateTime>> property)
        {
            return new DateTimeValidationBuilder<T>(property,validators);
        }
    }
}