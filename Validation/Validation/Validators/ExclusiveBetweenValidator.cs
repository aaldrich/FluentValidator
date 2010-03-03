using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class ExclusiveBetweenValidator<T,TProperty> : IValidator<T> where TProperty : IComparable
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty lower_range;
        readonly TProperty upper_range;

        public ExclusiveBetweenValidator(Expression<Func<T,TProperty>> expression, TProperty lower_range, TProperty upper_range)
        {
            this.expression = expression;
            this.lower_range = lower_range;
            this.upper_range = upper_range;
        }

        /// <summary>
        /// Validates that the value exclusively falls between the lower and upper range
        /// </summary>
        /// <param name="value">The value to compare</param>
        /// <returns>true if it falls between, false if not</returns>
        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var original_delegate = compiled.Invoke(value);

            var is_greater_than_lower = original_delegate.CompareTo(lower_range) > 0;
            var is_less_than_upper = original_delegate.CompareTo(upper_range) < 0;

            return (is_greater_than_lower && is_less_than_upper);
        }
    }
}