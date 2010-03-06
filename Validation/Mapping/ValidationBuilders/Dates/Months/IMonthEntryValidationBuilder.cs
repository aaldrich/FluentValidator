namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthEntryValidationBuilder<T> : IValidationBuilder<T>
    {
        IMonthPartValidationBuilder<T> should_be();
        IMonthPartValidationBuilder<T> should_not_be();
    }
}