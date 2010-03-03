using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public ByteValidationBuilder<T> Map(Expression<Func<T, byte>> property)
        {
            return new ByteValidationBuilder<T>(property,validators);
        }
    }
}