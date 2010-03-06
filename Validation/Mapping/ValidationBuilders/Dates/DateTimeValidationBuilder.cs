using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Mapping.ValidationBuilders.Dates.Years;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public class DateTimeValidationBuilder<T>: IDateTimeEntryValidationBuilder<T>
    {
        readonly Expression<Func<T, DateTime>> expression;
        public IList<IValidator<T>> validators { get; set; }

        public DateTimeValidationBuilder(Expression<Func<T, DateTime>> expression, IList<IValidator<T>> validators)
        {
            this.expression = expression;
            this.validators = validators;
        }

        public IMonthEntryValidationBuilder<T> month()
        {
            return new MonthValidationBuilder<T>(expression, validators);
        }

        public IYearEntryValidationBuilder<T> year()
        {
            return new YearValidationBuilder<T>(expression, validators);
        }

        public IDateEntryValidationBuilder<T> date()
        {
            return new DateValidationBuilder<T>(expression, validators);
        }
    }
}