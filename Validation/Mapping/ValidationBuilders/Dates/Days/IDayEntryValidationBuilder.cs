namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    public interface IDayEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IDayPartValidationBuilder<T> should_be();
        IDayPartValidationBuilder<T> should_not_be();
    }
}