using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class LessThanValidator<T,TProperty> : ValidatorBase<T>, IValidator<T>
        where TProperty : IComparable
        where T : class 
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty comparison_value;

        public LessThanValidator(Expression<Func<T,TProperty>> expression, TProperty comparison_value)
        {
            this.expression = expression;
            this.comparison_value = comparison_value;
        }

        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var compiled = expression.Compile();
            var original_delegate = compiled.Invoke(value);

            var result =  original_delegate.CompareTo(comparison_value) < 0;

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result;
        }
    }
}