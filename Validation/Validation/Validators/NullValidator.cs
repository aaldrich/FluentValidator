using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class NullValidator<T, TProperty> : IValidator<T> where TProperty : class
    {
        readonly Expression<Func<T, TProperty>> expression;

        public NullValidator(Expression<Func<T, TProperty>> expression)
        {
            this.expression = expression;
        }

        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var invoked = compiled.Invoke(value);

            return invoked != null;
        }
    }
}