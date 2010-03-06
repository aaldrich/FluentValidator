using System;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    /// <summary>
    /// A partial class of DayValidationBuilder. This is just to make the 
    /// code easier to read. It was getting to bulky having all the implementation
    /// of all the code in one file.
    /// </summary>
    public partial class DayValidationBuilder<T> 
    {
        public IDaySpecificationValidationBuilder<T> less_than()
        {
            day_building_context = less_than;
            return this;
        }

        CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>> less_than(DayOfWeek day_of_week)
        {
            Expression<Func<T, DayOfWeek>> lambda = get_day_of_week_expression();

            var validator = new LessThanValidator<T, DayOfWeek>(lambda, day_of_week);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(int day_of_month)
        {
            Expression<Func<T, int>> lambda = get_day_of_month_expression();

            var validator = new LessThanValidator<T, int>(lambda, day_of_month);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        public IDaySpecificationValidationBuilder<T> greater_than()
        {
            day_building_context = greater_than;
            return this;
        }

        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(DayOfWeek day_of_week)
        {
            Expression<Func<T, DayOfWeek>> lambda = get_day_of_week_expression();

            var validator = new GreaterThanValidator<T,DayOfWeek>(lambda, day_of_week);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(int day_of_month)
        {
            Expression<Func<T, int>> lambda = get_day_of_month_expression();

            var validator = new GreaterThanValidator<T, int>(lambda, day_of_month);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        public IDaySpecificationValidationBuilder<T> equal_to()
        {
            day_building_context = equal_to;
            return this;
        }

        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(DayOfWeek day_of_week)
        {
            Expression<Func<T, DayOfWeek>> lambda = get_day_of_week_expression();

            var validator = new EqualsValidator<T, DayOfWeek>(lambda, day_of_week);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(int day_of_month)
        {
            Expression<Func<T, int>> lambda = get_day_of_month_expression();

            var validator = new EqualsValidator<T, int>(lambda, day_of_month);
            add_validator_with_not_wrapper_if_needed(validator);

            return new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower_day_of_month">lower range (less than equal to)</param>
        /// <param name="upper_day_of_month">upper_day_of_month range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>>,int> between(int lower_day_of_month, int upper_day_of_month)
        {
            Expression<Func<T, int>> lambda = get_day_of_month_expression();

            var inclusive_validator =
                new InclusiveBetweenValidator<T, int>(lambda, lower_day_of_month, upper_day_of_month);
            add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>, int>(
                lambda,inclusive_validator,
                new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(
                    new DateTimeValidationBuilder<T>(expression,validators)),
                lower_day_of_month, upper_day_of_month);
        }

        public BetweenValidationBuilder<T, CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>, DayOfWeek> between(DayOfWeek lower, DayOfWeek upper)
        {
            Expression<Func<T, DayOfWeek>> lambda = get_day_of_week_expression();

            var inclusive_validator =
                new InclusiveBetweenValidator<T, DayOfWeek>(lambda, lower, upper);
            add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>, DayOfWeek>(
                lambda, inclusive_validator,
                new CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>(
                    new DateTimeValidationBuilder<T>(expression, validators)),
                lower, upper);
        }   
    }
}