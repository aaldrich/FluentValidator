using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public class StringContainsValidator<T> : ValidatorBase<T>, IValidator<T>
        where T : class
    {
        readonly Expression<Func<T, string>> expression;
        readonly string expected_value;

        public StringContainsValidator(Expression<Func<T, string>> expression, string expected_value)
        {
            if (expected_value == null)
                throw new ArgumentNullException("expected_value","expected value cannot be null" );

            this.expression = expression;
            this.expected_value = expected_value;
            this.failure_message_strategy = new ExpressionFailureMessageStrategy(
                expression.Body as MemberExpression, "a value containing",expected_value.ToString());
        }

        /// <summary>
        /// Validates that an value contains the expected value.
        /// Uses ICollection to determine if the value is empty.
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <returns>true if not empty, false if empty</returns>
        public bool Validate(T value)
        {
            if(value == null)
                return false;
            
            var compiled = expression.Compile();
            var original_delegate = compiled.Invoke(value);

            var result = original_delegate.Contains(expected_value);

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result; 
        }
    }
}