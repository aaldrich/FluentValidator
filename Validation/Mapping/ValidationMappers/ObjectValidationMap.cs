using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public ObjectValidationBuilder<T> Map(Expression<Func<T, object>> property)
        {
            return new ObjectValidationBuilder<T>(property, validators);
        }
    }
}