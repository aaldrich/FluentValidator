using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class GreaterThanValidator<T,TProperty>: IValidator<T> where TProperty : IComparable
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty greater_than_value;

        public GreaterThanValidator(Expression<Func<T,TProperty>> expression, TProperty greater_than_value)
        {
            this.expression = expression;
            this.greater_than_value = greater_than_value;
        }

        /// <summary>
        /// Validates the expression invocation value is greater than the greater than value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>true if it is greater, false if not</returns>
        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var original_delegate = expression.Compile();
            var property_value = original_delegate.Invoke(value);

            return property_value.CompareTo(greater_than_value) > 0;
        }
    }
}