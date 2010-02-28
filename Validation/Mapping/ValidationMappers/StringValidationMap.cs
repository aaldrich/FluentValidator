using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T>
    {
        public StringValidationBuilder<T> Map(Expression<Func<T, string>> property)
        {
            return new StringValidationBuilder<T>(property,validators);
        }
    }
}