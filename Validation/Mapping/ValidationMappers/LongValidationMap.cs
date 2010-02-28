using System;
using System.Linq.Expressions;
using Validation.Helpers;
using Validation.Mapping.ValidationBuilders;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public LongValidationBuilder<T> Map(Expression<Func<T, long>> property)
        {
            return new LongValidationBuilder<T>(property,validators);
        }
    }
}