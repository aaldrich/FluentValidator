using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    /// <summary>
    /// Handles building Month Validation. It is broken up into several partial classes
    /// to make it easier to read. Uses a progressive interface to lead the user down
    /// the correct path for usage.
    /// </summary>
    /// <typeparam name="T">The Generic Type to validate.</typeparam>
    /// The current builder being used to get here. Probably DateTimeValidationBuilder.
    /// </typeparam>
    public partial class MonthValidationBuilder<T> : CanWrapWithNotValidationBuilder<T>,
                                                     IMonthEntryValidationBuilder<T>,
                                                     IMonthPartValidationBuilder<T>,
                                                     IMonthSpecificationValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, DateTime>> expression;
        
        Func<Month,IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>> month_building_context;
        
        public MonthValidationBuilder(Expression<Func<T,DateTime>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IMonthPartValidationBuilder<T> should_be()
        {
            return this;
        }

        public IMonthPartValidationBuilder<T> should_not_be()
        {
            should_wrap_with_not = true;
            return this; 
        }
        
        Expression<Func<T, int>> get_month_expression()
        {
            Expression func = Expression.Property(expression.Body, "Month");
            return Expression.Lambda<Func<T, int>>(func, expression.Parameters);
        }
    }
}