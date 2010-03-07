using System;

namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    public partial class DayValidationBuilder<T> where T : class
    {
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> build_day(DayOfWeek day)
        {
            return (CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>)day_building_context.Invoke(day);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Sunday()
        {
            return build_day(DayOfWeek.Sunday); 
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Monday()
        {
            return build_day(DayOfWeek.Monday);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Tuesday()
        {
            return build_day(DayOfWeek.Tuesday);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Wednesday()
        {
            return build_day(DayOfWeek.Wednesday);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Thursday()
        {
            return build_day(DayOfWeek.Thursday);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Friday()
        {
            return build_day(DayOfWeek.Friday);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Saturday()
        {
            return build_day(DayOfWeek.Saturday);
        }
    }
}