namespace Validation.Mapping.ValidationBuilders.Dates
{
    public interface IDateEntryValidationBuilder<T> where T : class
    {
        IDateSpecificationValidationBuilder<T> should_be();
        IDateSpecificationValidationBuilder<T> should_not_be();
    }
}