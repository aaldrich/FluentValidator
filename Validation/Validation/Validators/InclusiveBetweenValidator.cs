using System;
using System.Linq.Expressions;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public class InclusiveBetweenValidator<T,TProperty> : ValidatorBase<T>, IValidator<T> 
        where TProperty : IComparable
        where T : class 
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty lower_range;
        readonly TProperty upper_range;

        public InclusiveBetweenValidator(Expression<Func<T,TProperty>> expression, TProperty lower_range, TProperty upper_range)
        {
            this.expression = expression;
            this.lower_range = lower_range;
            this.upper_range = upper_range;
            this.failure_message_strategy = new ExpressionFailureMessageStrategy(
                expression.Body as MemberExpression,
                String.Format("greater than or equal to {0} and less than or equal to", lower_range), upper_range.ToString());
        }

        /// <summary>
        /// Validates that the value inclusively falls between the lower and upper range
        /// </summary>
        /// <param name="value">The value to compare</param>
        /// <returns>true if it falls between, false if not</returns>
        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var original_delegate = compiled.Invoke(value);

            var is_greater_than_lower = original_delegate.CompareTo(lower_range) >= 0;
            var is_less_than_upper = original_delegate.CompareTo(upper_range) <= 0;

            var result = (is_greater_than_lower && is_less_than_upper);

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result;
        }
    }
}