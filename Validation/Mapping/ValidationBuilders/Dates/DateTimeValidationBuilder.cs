using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Date
{
    public class DateTimeValidationBuilder<T>: ValidationBuilder<T>
    {
        readonly Expression<Func<T, DateTime>> expression;

        public DateTimeValidationBuilder(Expression<Func<T, System.DateTime>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public IMonthEntryValidationBuilder<T, DateTimeValidationBuilder<T>> month()
        {
            return new MonthValidationBuilder<T, DateTimeValidationBuilder<T>>(expression,this);
        }

        public CompositeValidationBuilder<T, DateTimeValidationBuilder<T>> greater_than(System.DateTime value)
        {
            var greater_than_validator = new GreaterThanValidator<T, System.DateTime>(expression, value);
            validators.Add(greater_than_validator);
            return new CompositeValidationBuilder<T, DateTimeValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, DateTimeValidationBuilder<T>> not(System.DateTime value)
        {
            var not_validator = new NotValidator<T, System.DateTime>(expression, value);
            validators.Add(not_validator);
            return new CompositeValidationBuilder<T,DateTimeValidationBuilder<T>>(this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,DateTimeValidationBuilder<T>,System.DateTime> between(System.DateTime lower, System.DateTime upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, System.DateTime>(expression, lower, upper);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, DateTimeValidationBuilder<T>,System.DateTime>(expression,inclusive_validator,this,lower,upper);
        }
    }
}