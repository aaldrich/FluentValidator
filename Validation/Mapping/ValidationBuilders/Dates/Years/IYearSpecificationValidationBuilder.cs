using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Dates.Years
{
    public interface IYearSpecificationValidationBuilder<T> where T : class
    {
        BetweenValidationBuilder<T, IDateTimeEntryValidationBuilder<T>, int> between(int lower, int upper);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(int year);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(int year);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than_or_equal_to(int year);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than_or_equal_to(int year);
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(int year);
    }
}