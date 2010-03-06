using System;

namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    public interface IDayPartValidationBuilder<T>
    {
        BetweenValidationBuilder<T,CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>>,DayOfWeek>
            between(DayOfWeek lower, DayOfWeek upper);
        BetweenValidationBuilder<T, CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>, int>
            between(int lower_day_of_month, int upper_day_of_month_day_of_month);
        IDaySpecificationValidationBuilder<T> less_than();
        CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>> less_than(int day_of_month);
        IDaySpecificationValidationBuilder<T> greater_than();
        CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>> greater_than(int day_of_month);
        IDaySpecificationValidationBuilder<T> equal_to();    
        CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>> equal_to(int day_of_month);
    }
}