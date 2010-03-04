using System;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    /// <summary>
    /// Handles building Month Validation. It is broken up into several partial classes
    /// to make it easier to read. Uses a progressive interface to lead the user down
    /// the correct path for usage.
    /// </summary>
    /// <typeparam name="T">The Generic Type to validate.</typeparam>
    /// <typeparam name="TCurrentBuilder">
    /// The current builder being used to get here. Probably DateTimeValidationBuilder.
    /// </typeparam>
    public partial class MonthValidationBuilder<T,TCurrentBuilder> : CanWrapWithNotValidationBuilder<T>,
                                                                     IMonthEntryValidationBuilder<T,TCurrentBuilder>,
                                                                     IMonthPartValidationBuilder<T,TCurrentBuilder>,
                                                                     IMonthSpecificationValidationBuilder<T,TCurrentBuilder>
        where TCurrentBuilder : ValidationBuilder<T>
    {
        readonly Expression<Func<T, DateTime>> expression;
        TCurrentBuilder current_builder;
        
        Func<Month,ValidationBuilder<T>> month_building_context;
        
        public MonthValidationBuilder(Expression<Func<T,DateTime>> expression,TCurrentBuilder current_builder)
            : base(current_builder.validators)
        {
            this.expression = expression;
            this.current_builder = current_builder;
        }

        public IMonthPartValidationBuilder<T, TCurrentBuilder> should_be()
        {
            return this;
        }

        public IMonthPartValidationBuilder<T, TCurrentBuilder> should_not_be()
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

namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthEntryValidationBuilder<T, TCurrentBuilder>
            where TCurrentBuilder : ValidationBuilder<T>
    {
        IMonthPartValidationBuilder<T, TCurrentBuilder> should_be();
        IMonthPartValidationBuilder<T, TCurrentBuilder> should_not_be();
    }
}