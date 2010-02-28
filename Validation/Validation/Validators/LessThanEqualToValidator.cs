using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class LessThanEqualToValidator<T,TProperty>: IValidator<T> where TProperty : IComparable
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty comparison_value;

        public LessThanEqualToValidator(Expression<Func<T,TProperty>> expression, TProperty comparison_value)
        {
            this.expression = expression;
            this.comparison_value = comparison_value;
        }

        /// <summary>
        /// Validates the expression invocation value is less than or equal to the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>true if it is less or equal, false if not</returns>
        public bool Validate(T value)
        {
            var original_delegate = expression.Compile();
            var property_value = original_delegate.Invoke(value);

            return property_value.CompareTo(comparison_value) <= 0;
        }
    }
}