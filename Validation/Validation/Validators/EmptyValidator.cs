using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Validation.Validation.Validators
{
    public class EmptyValidator<T,TProperty> : IValidator<T> where TProperty : IEnumerable
    {
        readonly Expression<Func<T, TProperty>> expression;

        public EmptyValidator(Expression<Func<T,TProperty>> expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Validates that an value is not empty.
        /// Uses IEnumerable to determine if the value is empty.
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <returns>true if not empty, false if empty</returns>
        public bool Validate(T value)
        {
            var compiled = expression.Compile();
            var original_delegate = compiled.Invoke(value);

            var enumerator = original_delegate.GetEnumerator();
            enumerator.Reset();
            
            return enumerator.MoveNext();
        }
    }
}