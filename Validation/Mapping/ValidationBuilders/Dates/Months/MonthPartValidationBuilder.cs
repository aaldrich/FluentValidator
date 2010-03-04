using System;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    /// <summary>
    /// A partial class of MonthValidationBuilder. This is just to make the 
    /// code easier to read. It was getting to bulky having all the implementation
    /// of all the code in one file.
    /// </summary>
    public partial class MonthValidationBuilder<T, TCurrentBuilder> 
    {
        public IMonthSpecificationValidationBuilder<T, TCurrentBuilder> less_than()
        {
            month_building_context = less_than;
            return this;
        }

        CompositeValidationBuilder<T, TCurrentBuilder> less_than(Month month)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var validator = new LessThanValidator<T, int>(lambda, month.value);
            add_validator_with_not_wrapper_if_needed(validator);

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

            var validator = new GreaterThanValidator<T, int>(lambda, month.value);
            add_validator_with_not_wrapper_if_needed(validator);

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

            var validator = new EqualsValidator<T, int>(lambda, month.value);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, TCurrentBuilder>(current_builder);
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
            add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, MonthValidationBuilder<T, TCurrentBuilder>, int>(lambda, inclusive_validator, this, lower.value, upper.value);
        }   
    }
}