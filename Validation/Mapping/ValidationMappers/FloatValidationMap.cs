using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Numeric.Floats;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public IFloatEntryValidationBuilder<T> Map(Expression<Func<T, float>> property)
        {
            return new FloatValidationBuilder<T>(property, validators, ignore_validators);
        }
    }
}