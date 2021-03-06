using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Objects;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public IObjectEntryValidationBuilder<T> Map(Expression<Func<T, object>> property)
        {
            return new ObjectValidationBuilder<T>(property, validators,ignore_validators);
        }
    }
}