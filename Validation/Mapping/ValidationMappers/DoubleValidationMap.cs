using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric.Doubles;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public IDoubleEntryValidationBuilder<T> Map(Expression<Func<T, double>> property)
        {
            return new DoubleValidationBuilder<T>(property,validators,ignore_validators);
        }
    }
}