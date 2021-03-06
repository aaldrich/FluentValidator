using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Strings;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public IStringEntryValidationBuilder<T> Map(Expression<Func<T, string>> property)
        {
            return new StringValidationBuilder<T>(property, validators, ignore_validators);
        }
    }
}