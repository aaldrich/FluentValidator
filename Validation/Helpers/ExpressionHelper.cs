using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Validation.Helpers
{
    public class ExpressionHelper
    {
        public static Type GetPropertyType<T>(Expression<Func<T,object>> expression)
        {
            var unary_expression = expression.Body as UnaryExpression;

            if (unary_expression == null)
                throw new InvalidOperationException("Not a unary expression");

            return unary_expression.Operand.Type;
        }
    }
}