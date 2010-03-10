using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Validation.Helpers
{
    public class ExpressionHelper
    {
        public static Type GetMemberType<T,TProperty>(Expression<Func<T,TProperty>> expression)
        {
            return get_member_expression(expression).Type;
        }

        public static string GetMemberName<T,TProperty>(Expression<Func<T,TProperty>> expression)
        {
            return get_member_expression(expression).Member.Name;
        }

        static MemberExpression get_member_expression<T,TProperty>(Expression<Func<T,TProperty>> expression)
        {
            MemberExpression member_expression;

            if (is_unary_expression(expression.Body))
                member_expression = get_member_expression_from_unary_expression(expression.Body as UnaryExpression);
            else
                member_expression = expression.Body as MemberExpression;

            if (member_expression == null)
                throw new ArgumentException("member_expression is not a MemberExpression");

            return member_expression;
        }

        static MemberExpression get_member_expression_from_unary_expression(UnaryExpression expression)
        {
            var member_expression = expression.Operand as MemberExpression;
            return member_expression;
        }

        static bool is_unary_expression(Expression expression)
        {
            return (expression as UnaryExpression) == null ? false : true;
        }
    }
}