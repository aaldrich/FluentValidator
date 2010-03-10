using System;
using System.Linq.Expressions;
using Validation.Helpers;
using Validation.Mapping.ValidationBuilders;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> where T : class
    {
        public BooleanValidationBuilder<T> Map(Expression<Func<T, bool>> property)
        {
            return new BooleanValidationBuilder<T>(property,validators,ignore_validators);
        }
    }
}