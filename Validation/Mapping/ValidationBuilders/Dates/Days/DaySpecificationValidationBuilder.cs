using System;
using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    public partial class DayValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> build_day(DayOfWeek day)
        {
            return day_building_context.Invoke(day);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Sunday()
        {
            return build_day(DayOfWeek.Sunday); 
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Monday()
        {
            return build_day(DayOfWeek.Monday);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Tuesday()
        {
            return build_day(DayOfWeek.Tuesday);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Wednesday()
        {
            return build_day(DayOfWeek.Wednesday);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Thursday()
        {
            return build_day(DayOfWeek.Thursday);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Friday()
        {
            return build_day(DayOfWeek.Friday);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Saturday()
        {
            return build_day(DayOfWeek.Saturday);
        }
    }
}