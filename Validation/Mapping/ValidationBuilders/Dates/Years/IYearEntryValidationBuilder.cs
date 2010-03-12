namespace Validation.Mapping.ValidationBuilders.Dates.Years
{
    public interface IYearEntryValidationBuilder<T> where T : class
    {
        IYearSpecificationValidationBuilder<T> should_be();
        IYearSpecificationValidationBuilder<T> should_not_be();
    }
}