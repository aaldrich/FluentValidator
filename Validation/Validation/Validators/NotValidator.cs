using System;
using System.Linq.Expressions;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public class NotValidator<T, TProperty> : ValidatorBase<T>, IValidator<T>
        where TProperty : IComparable
        where T : class
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty comparison_value;

        public NotValidator(Expression<Func<T, TProperty>> expression, TProperty comparison_value)
        {
            this.expression = expression;
            this.comparison_value = comparison_value;
            this.failure_message_strategy = new ExpressionFailureMessageStrategy(
                expression.Body as MemberExpression, "not equal to", comparison_value.ToString());
        }

        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var invoked = compiled.Invoke(value);

            var result = invoked.CompareTo(comparison_value) != 0 ;

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result;
        }
    }
}