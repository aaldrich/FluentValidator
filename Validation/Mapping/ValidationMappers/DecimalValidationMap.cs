using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public DecimalValidationBuilder<T> Map(Expression<Func<T, decimal>> property)
        {
            return new DecimalValidationBuilder<T>(property,validators);
        }
    }
}