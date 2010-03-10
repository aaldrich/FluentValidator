using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Years
{
    /// <summary>
    /// Handles building Year Validation. It is broken up into several partial classes
    /// to make it easier to read. Uses a progressive interface to lead the user down
    /// the correct path for usage.
    /// </summary>
    /// <typeparam name="T">The Generic Type to validate.</typeparam>
    /// The current builder being used to get here. Probably DateTimeValidationBuilder.
    /// </typeparam>
    public partial class YearValidationBuilder<T> : CanWrapWithNotValidationBuilder<T>,
                                                    IYearEntryValidationBuilder<T>,
                                                    IYearPartValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, DateTime>> expression;
        
        public YearValidationBuilder(Expression<Func<T,DateTime>> expression,IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IYearPartValidationBuilder<T> should_be()
        {
            return this;
        }

        public IYearPartValidationBuilder<T> should_not_be()
        {
            should_wrap_with_not = true;
            return this; 
        }
        
        Expression<Func<T, int>> get_year_expression()
        {
            Expression func = Expression.Property(expression.Body, "Year");
            return Expression.Lambda<Func<T, int>>(func, expression.Parameters);
        }
    }
}