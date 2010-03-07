using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class LessThanEqualToValidator<T,TProperty>: ValidatorBase<T>, IValidator<T>
        where TProperty : IComparable
        where T : class 
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
            if (value == null)
                return false;

            var original_delegate = expression.Compile();
            var property_value = original_delegate.Invoke(value);

            var result =  property_value.CompareTo(comparison_value) <= 0;

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result;
        }
    }
}