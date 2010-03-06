using System;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public interface IDatePartValidationBuilder<T>
    {
        BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, DateTime> between(DateTime lower, DateTime upper);
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(DateTime date_time);
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(DateTime date_time);
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(DateTime date_time);
    }
}