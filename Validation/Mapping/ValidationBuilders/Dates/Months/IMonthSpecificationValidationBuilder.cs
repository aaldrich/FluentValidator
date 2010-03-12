using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> January();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> February();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> March();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> April();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> May();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> June();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> July();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> August();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> September();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> October();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> November();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> December();
    }
}