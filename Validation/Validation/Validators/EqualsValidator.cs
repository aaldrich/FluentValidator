using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class EqualsValidator<T,TProperty>: ValidatorBase<T>, IValidator<T>
        where T : class 
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly TProperty equals_value;
        
        public EqualsValidator(Expression<Func<T,TProperty>> expression, TProperty value)
        {
            this.expression = expression;
            this.equals_value = value;
        }

        public bool Validate(T value)
        {
            if (value == null)
                return false;

            var original_delegate = expression.Compile();
            var property_value = original_delegate.Invoke(value);
            
            var result = property_value.Equals(equals_value);

            if ((!result) && (null != execute_upon_failure))
                execute_upon_failure(value);

            return result; 
        }
    }
}