using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    /// <summary>
    /// Handles building Day Validation. It is broken up into several partial classes
    /// to make it easier to read. Uses a progressive interface to lead the user down
    /// the correct path for usage.
    /// </summary>
    /// <typeparam name="T">The Generic Type to validate.</typeparam>
    /// The current builder being used to get here. Probably DateTimeValidationBuilder.
    /// </typeparam>
    public partial class DayValidationBuilder<T> : CanWrapWithNotValidationBuilder<T>,
                                                     IDayEntryValidationBuilder<T>,
                                                     IDayPartValidationBuilder<T>,
                                                     IDaySpecificationValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, DateTime>> expression;
        
        Func<DayOfWeek,IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>> day_building_context;
        
        public DayValidationBuilder(Expression<Func<T,DateTime>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IDayPartValidationBuilder<T> should_be()
        {
            return this;
        }

        public IDayPartValidationBuilder<T> should_not_be()
        {
            should_wrap_with_not = true;
            return this; 
        }
        
        Expression<Func<T, DayOfWeek>> get_day_of_week_expression()
        {
            Expression func = Expression.Property(expression.Body, "DayOfWeek");
            return Expression.Lambda<Func<T, DayOfWeek>>(func, expression.Parameters);
        }

        Expression<Func<T, int>> get_day_of_month_expression()
        {
            Expression func = Expression.Property(expression.Body, "Day");
            return Expression.Lambda<Func<T, int>>(func, expression.Parameters);
        }
    }
}