using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric.Bytes;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public IByteEntryValidationBuilder<T> Map(Expression<Func<T, byte>> property)
        {
            return new ByteValidationBuilder<T>(property, validators, ignore_validators);
        }
    }
}