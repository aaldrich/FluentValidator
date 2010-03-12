using System;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public partial class DateValidationBuilder<T> where T : class
    {
        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(DateTime value)
        {
            var validator = new GreaterThanValidator<T, DateTime>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator,validators,ignore_validators, new DateTimeValidationBuilder<T>(expression, validators, ignore_validators));
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(DateTime value)
        {
            var validator = new EqualsValidator<T, DateTime>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator, validators, ignore_validators, new DateTimeValidationBuilder<T>(expression, validators, ignore_validators));
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(DateTime value)
        {
            var validator = new LessThanValidator<T, DateTime>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>
                (validator, validators, ignore_validators, new DateTimeValidationBuilder<T>(expression, validators, ignore_validators));
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> not(DateTime value)
        {
            var validator = new NotValidator<T, DateTime>(expression, value);
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
        public BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, DateTime> between(DateTime lower, DateTime upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, DateTime>(expression, lower, upper);

            base.add_validator_with_not_wrapper_if_needed(inclusive_validator);
            return new BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, DateTime>
                (expression, inclusive_validator, new DateTimeValidationBuilder<T>(expression,validators,ignore_validators), lower, upper);
        }
    }
}