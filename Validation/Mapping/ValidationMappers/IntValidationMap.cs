using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public IntValidationBuilder<T> Map(Expression<Func<T, int>> property)
        {
            return new IntValidationBuilder<T>(property,validators);
        }
    }
}