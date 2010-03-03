using System;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class EqualsValidator<T,TProperty>: IValidator<T>
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
            
            return property_value.Equals(equals_value);
        }
    }
}