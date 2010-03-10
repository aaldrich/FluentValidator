using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric.Integers;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public IIntegerEntryValidationBuilder<T> Map(Expression<Func<T, int>> property)
        {
            return new IntValidationBuilder<T>(property, validators, ignore_validators);
        }
    }
}