using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public LongValidationBuilder<T> Map(Expression<Func<T, long>> property)
        {
            return new LongValidationBuilder<T>(property,validators);
        }
    }
}