using System;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates.Years
{
    /// <summary>
    /// A partial class of YearValidationBuilder. This is just to make the 
    /// code easier to read. It was getting to bulky having all the implementation
    /// of all the code in one file.
    /// </summary>
    public partial class YearValidationBuilder<T> where T : class
    {
        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(int year)
        {
            Expression<Func<T, int>> lambda = get_year_expression();

            var validator = new LessThanValidator<T, int>(lambda, year);
            base.add_validator_with_not_wrapper_if_needed(validator);

            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator,validators,ignore_validators,new DateTimeValidationBuilder<T>(expression,validators,ignore_validators));
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than_or_equal_to(int year)
        {
            Expression<Func<T, int>> lambda = get_year_expression();

            var validator = new LessThanEqualToValidator<T, int>(lambda, year);
            base.add_validator_with_not_wrapper_if_needed(validator);

            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator, validators, ignore_validators, new DateTimeValidationBuilder<T>(expression, validators, ignore_validators));
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(int year)
        {
            Expression<Func<T, int>> lambda = get_year_expression();

            var validator = new GreaterThanValidator<T, int>(lambda, year);
            base.add_validator_with_not_wrapper_if_needed(validator);

            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator, validators, ignore_validators, new DateTimeValidationBuilder<T>(expression, validators, ignore_validators));
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than_or_equal_to(int year)
        {
            Expression<Func<T, int>> lambda = get_year_expression();

            var validator = new GreaterThanEqualToValidator<T, int>(lambda, year);
            base.add_validator_with_not_wrapper_if_needed(validator);

            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator, validators, ignore_validators, new DateTimeValidationBuilder<T>(expression, validators, ignore_validators));
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(int year)
        {
            Expression<Func<T, int>> lambda = get_year_expression();

            var validator = new EqualsValidator<T, int>(lambda, year); 
            base.add_validator_with_not_wrapper_if_needed(validator);

            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator, validators, ignore_validators, new DateTimeValidationBuilder<T>(expression, validators, ignore_validators));
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, int> between(int lower, int upper)
        {
            Expression<Func<T, int>> lambda = get_year_expression();

            var inclusive_validator =
                new InclusiveBetweenValidator<T, int>(lambda, lower, upper);
            base.add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, int>(
                lambda, inclusive_validator,
                new DateTimeValidationBuilder<T>(expression,validators,ignore_validators),
                lower, upper);
        }   
    }
}