using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public DoubleValidationBuilder<T> Map(Expression<Func<T, double>> property)
        {
            return new DoubleValidationBuilder<T>(property,validators);
        }
    }
}