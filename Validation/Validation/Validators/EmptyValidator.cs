using System;
using System.Collections;
using System.Linq.Expressions;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public class EmptyValidator<T,TProperty> : ValidatorBase<T>, IValidator<T>
        where TProperty : IEnumerable
        where T : class 
    {
        readonly Expression<Func<T, TProperty>> expression;

        public EmptyValidator(Expression<Func<T,TProperty>> expression)
        {
            this.expression = expression;
            this.failure_message_strategy = new ExpressionFailureMessageStrategy(
                expression.Body as MemberExpression, String.Empty, "non empty");
        }

        /// <summary>
        /// Validates that an value is not empty.
        /// Uses IEnumerable to determine if the value is empty.
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <returns>true if not empty, false if empty</returns>
        public bool Validate(T value)
        {
            if(value == null)
                return false;

            var compiled = expression.Compile();
            var original_delegate = compiled.Invoke(value);

            var enumerator = original_delegate.GetEnumerator();
            enumerator.Reset();

            var result = enumerator.MoveNext();

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result; 
        }
    }
}