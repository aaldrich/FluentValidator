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
    public partial class MonthValidationBuilder<T> where T : class
    {
        public IMonthSpecificationValidationBuilder<T> less_than()
        {
            month_building_context = less_than;
            return this;
        }

        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(Month month)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var validator = new LessThanValidator<T, int>(lambda, month.value);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        public IMonthSpecificationValidationBuilder<T> greater_than()
        {
            month_building_context = greater_than;
            return this;
        }

        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(Month month)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var validator = new GreaterThanValidator<T, int>(lambda, month.value);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        public IMonthSpecificationValidationBuilder<T> equal_to()
        {
            month_building_context = equal_to;
            return this;
        }

        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(Month month)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var validator = new EqualsValidator<T, int>(lambda, month.value);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>>,int> between(Month lower, Month upper)
        {
            Expression<Func<T, int>> lambda = get_month_expression();

            var inclusive_validator =
                new InclusiveBetweenValidator<T, int>(lambda, lower.value, upper.value);
            add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>, int>(
                lambda,inclusive_validator,
                new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(
                    new DateTimeValidationBuilder<T>(expression,validators)),
                lower.value, upper.value);
        }   
    }
}