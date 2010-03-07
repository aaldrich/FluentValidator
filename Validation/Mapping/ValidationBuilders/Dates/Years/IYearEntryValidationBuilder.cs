namespace Validation.Mapping.ValidationBuilders.Dates.Years
{
    public interface IYearEntryValidationBuilder<T> where T : class
    {
        IYearPartValidationBuilder<T> should_be();
        IYearPartValidationBuilder<T> should_not_be();
    }
}