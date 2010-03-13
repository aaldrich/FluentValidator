using System;
using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public interface IDateSpecificationValidationBuilder<T> where T : class
    {
        BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, DateTime> between(DateTime lower, DateTime upper);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(DateTime date_time);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(DateTime date_time);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than_or_equal_to(DateTime date_time);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than_or_equal_to(DateTime date_time);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(DateTime date_time);
    }
}