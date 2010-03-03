using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class BooleanValidator<T, TProperty> : IValidator<T> where TProperty : IComparable 
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty comparison_value;

        public BooleanValidator(Expression<Func<T, TProperty>> expression, TProperty comparison_value)
        {
            this.expression = expression;
            this.comparison_value = comparison_value;
        }

        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var invoked = compiled.Invoke(value);

            return invoked.CompareTo(comparison_value) == 0 ;
        }
    }
}