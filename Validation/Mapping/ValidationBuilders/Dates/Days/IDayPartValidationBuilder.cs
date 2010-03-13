using System;
using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    public interface IDayPartValidationBuilder<T> where T : class
    {
        BetweenValidationBuilder<T,IDateTimeEntryValidationBuilder<T>,DayOfWeek>
            between(DayOfWeek lower, DayOfWeek upper);
        BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, int>
            between(int lower_day_of_month, int upper_day_of_month_day_of_month);
        IDaySpecificationValidationBuilder<T> less_than();
        IDaySpecificationValidationBuilder<T> greater_than();
        IDaySpecificationValidationBuilder<T> equal_to();
        IDaySpecificationValidationBuilder<T> greater_than_or_equal_to();
        IDaySpecificationValidationBuilder<T> less_than_or_equal_to();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(int day_of_month);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(int day_of_month);
        IFailureEntryValidationBuilder<T,IDateTimeEntryValidationBuilder<T>> equal_to(int day_of_month);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than_or_equal_to(int day_of_month);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than_or_equal_to(int day_of_month);
    }
}