using System;
using System.Linq.Expressions;

namespace Validation.Validation.Failures
{
    public class ExpressionFailureMessageStrategy : IFailureMessageStrategy
    {
        readonly MemberExpression member_expression;
        readonly string validation_type;
        readonly string expected_value;

        public ExpressionFailureMessageStrategy(MemberExpression member_expression, string validation_type, string expected_value)
        {
            this.member_expression = member_expression;
            this.validation_type = validation_type;
            this.expected_value = expected_value;
        }

        public string get_failure_message()
        {
            if (member_expression == null || validation_type == null || expected_value == null)
                return String.Empty;

            var return_message = String.Format("{0} must be ",member_expression.Member.Name);
            return_message += get_expected_type_with_space_if_not_empty();
            return_message += expected_value;

            return return_message;
        }

        string get_expected_type_with_space_if_not_empty()
        {
            return String.IsNullOrEmpty(validation_type) ? String.Empty : String.Format("{0} ",validation_type);
        }
    }
}