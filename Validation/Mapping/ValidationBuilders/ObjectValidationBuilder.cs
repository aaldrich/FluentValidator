using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class ObjectValidationBuilder<T> : ValidationBuilder<T>
    {
        readonly Expression<Func<T, object>> expression;

        public ObjectValidationBuilder(Expression<Func<T, object>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public ObjectValidationBuilder<T> not_null()
        {
            var validator = new NullValidator<T, object>(expression);
            validators.Add(validator);
            return this;
        }
    }
}