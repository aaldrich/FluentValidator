using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Validation.Validation.Failures;

namespace Validation.Validation.Validators
{
    public class RegexValidator<T> : ValidatorBase<T>, IValidator<T> where T : class
    {
        readonly Expression<Func<T, string>> expression;
        readonly Regex regular_expression;

        public RegexValidator(Expression<Func<T, string>> expression, Regex regular_expression)
        {
            this.expression = expression;
            this.regular_expression = regular_expression;
            this.failure_message_strategy = new ExpressionFailureMessageStrategy(
                expression.Body as MemberExpression, "a value matching pattern", regular_expression.ToString());
        }

        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var original_delegate = compiled.Invoke(value);

            var result = regular_expression.IsMatch(original_delegate);

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result;
        }
    }
}