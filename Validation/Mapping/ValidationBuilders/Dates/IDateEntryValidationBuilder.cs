namespace Validation.Mapping.ValidationBuilders.Dates
{
    public interface IDateEntryValidationBuilder<T>
    {
        IDatePartValidationBuilder<T> should_be();
        IDatePartValidationBuilder<T> should_not_be();
    }
}