using System;
using System.Linq.Expressions;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public class NotNullValidator<T, TProperty> : ValidatorBase<T>, IValidator<T>
        where TProperty : class
        where T : class 
    {
        readonly Expression<Func<T, TProperty>> expression;

        public NotNullValidator(Expression<Func<T, TProperty>> expression)
        {
            this.expression = expression;
            this.failure_message_strategy = new ExpressionFailureMessageStrategy(
                expression.Body as MemberExpression, String.Empty, "non null");
        }

        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var invoked = compiled.Invoke(value);

            var result = invoked != null;

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result;
        }
    }
}