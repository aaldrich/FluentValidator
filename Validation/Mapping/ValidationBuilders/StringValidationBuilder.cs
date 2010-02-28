using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class StringValidationBuilder<T> : ValidationBuilder<T>
    {
        readonly Expression<Func<T, string>> expression;

        public StringValidationBuilder(Expression<Func<T, string>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T,StringValidationBuilder<T>> not_null()
        {
            var validator = new NullValidator<T, string>(expression);
            validators.Add(validator);
            return new CompositeValidationBuilder<T, StringValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T,StringValidationBuilder<T>> not_empty()
        {
            var validator = new EmptyValidator<T, string>(expression);
            validators.Add(validator);
            return new CompositeValidationBuilder<T, StringValidationBuilder<T>>(this);
        }
    }
}