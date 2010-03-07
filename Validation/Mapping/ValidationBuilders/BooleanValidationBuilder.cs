using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class BooleanValidationBuilder<T>: ValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, bool>> expression;

        public BooleanValidationBuilder(Expression<Func<T, bool>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T, BooleanValidationBuilder<T>> should_be_true()
        {
            return boolean_validate(true);
        }

        public CompositeValidationBuilder<T, BooleanValidationBuilder<T>> should_be_false()
        {
            return boolean_validate(false);
        }

        CompositeValidationBuilder<T, BooleanValidationBuilder<T>> boolean_validate(bool value)
        {
            var boolean_validator = new BooleanValidator<T, bool>(expression, value);
            validators.Add(boolean_validator);
            return new CompositeValidationBuilder<T, BooleanValidationBuilder<T>>(this);
        }
    }
}