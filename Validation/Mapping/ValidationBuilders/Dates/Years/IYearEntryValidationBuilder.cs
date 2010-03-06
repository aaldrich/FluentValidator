namespace Validation.Mapping.ValidationBuilders.Dates.Years
{
    public interface IYearEntryValidationBuilder<T>
    {
        IYearPartValidationBuilder<T> should_be();
        IYearPartValidationBuilder<T> should_not_be();
    }
}