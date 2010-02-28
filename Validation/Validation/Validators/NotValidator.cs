using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class NotValidator<T, TProperty> : IValidator<T> where TProperty : IComparable 
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty comparison_value;

        public NotValidator(Expression<Func<T, TProperty>> expression, TProperty comparison_value)
        {
            this.expression = expression;
            this.comparison_value = comparison_value;
        }

        public bool Validate(T value)
        {
            var compiled = expression.Compile();
            var invoked = compiled.Invoke(value);

            return invoked.CompareTo(comparison_value) != 0 ;
        }
    }
}