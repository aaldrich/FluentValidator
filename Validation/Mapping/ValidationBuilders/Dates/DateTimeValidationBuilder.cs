using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Dates.Days;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Mapping.ValidationBuilders.Dates.Years;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public class DateTimeValidationBuilder<T>: IDateTimeEntryValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, DateTime>> expression;
        public HashSet<IgnoreValidator> ignore_validators { get; set; }
        public IList<IValidator<T>> validators { get; set; }

        public DateTimeValidationBuilder(Expression<Func<T, DateTime>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
        {
            this.expression = expression;
            this.ignore_validators = ignore_validators;
            this.validators = validators;
        }

        public IMonthEntryValidationBuilder<T> month()
        {
            return new MonthValidationBuilder<T>(expression, validators,ignore_validators);
        }

        public IYearEntryValidationBuilder<T> year()
        {
            return new YearValidationBuilder<T>(expression, validators, ignore_validators);
        }

        public IDateEntryValidationBuilder<T> date()
        {
            return new DateValidationBuilder<T>(expression, validators, ignore_validators);
        }
        public IDayEntryValidationBuilder<T> day()
        {
            return new DayValidationBuilder<T>(expression, validators, ignore_validators);
        }
    }
}
