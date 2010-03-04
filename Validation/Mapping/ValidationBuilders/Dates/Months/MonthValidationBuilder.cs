using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Date;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Mapping.ValidationBuilders.Numeric;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public partial class MonthValidationBuilder<T,TCurrentBuilder> : ValidationBuilder<T>,
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

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T, MonthValidationBuilder<T, TCurrentBuilder>, int> between(Month lower, Month upper)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var inclusive_validator =
                 new InclusiveBetweenValidator<T, int>(lambda, lower.value, upper.value);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, MonthValidationBuilder<T, TCurrentBuilder>, int>(lambda, inclusive_validator, this, lower.value, upper.value);
        }

        public IMonthSpecificationValidationBuilder<T, TCurrentBuilder> less_than()
        {
            month_building_context = less_than;
            return this;
        }

        CompositeValidationBuilder<T, TCurrentBuilder> less_than(Month month)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var integer_validator = new LessThanValidator<T, int>(lambda, month.value);
            validators.Add(integer_validator);
            return new CompositeValidationBuilder<T, TCurrentBuilder>(current_builder);
        }

        public IMonthSpecificationValidationBuilder<T, TCurrentBuilder> greater_than()
        {
            month_building_context = greater_than;
            return this;
        }

        CompositeValidationBuilder<T, TCurrentBuilder> greater_than(Month month)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var integer_validator = new GreaterThanValidator<T, int>(lambda, month.value);
            validators.Add(integer_validator);
            return new CompositeValidationBuilder<T, TCurrentBuilder>(current_builder);
        }

        public IMonthSpecificationValidationBuilder<T, TCurrentBuilder> equal_to()
        {
            month_building_context = equal_to;
            return this;
        }

        CompositeValidationBuilder<T, TCurrentBuilder> equal_to(Month month)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var integer_validator = new EqualsValidator<T, int>(lambda, month.value);
            validators.Add(integer_validator);
            return new CompositeValidationBuilder<T, TCurrentBuilder>(current_builder);
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
    }

    public interface IMonthPartValidationBuilder<T, TCurrentBuilder>
        where TCurrentBuilder : ValidationBuilder<T>
    {
        BetweenValidationBuilder<T, MonthValidationBuilder<T,TCurrentBuilder>,int> between(Month lower, Month upper);
        IMonthSpecificationValidationBuilder<T, TCurrentBuilder> less_than();
        IMonthSpecificationValidationBuilder<T, TCurrentBuilder> greater_than();
        IMonthSpecificationValidationBuilder<T, TCurrentBuilder> equal_to();
    }
}