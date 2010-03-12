using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    public interface IDaySpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Sunday();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Monday();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Tuesday();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Wednesday();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Thursday();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Friday();
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Saturday();
    }
}