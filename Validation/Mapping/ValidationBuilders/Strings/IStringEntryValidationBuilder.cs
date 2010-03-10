namespace Validation.Mapping.ValidationBuilders.Strings
{
    public interface IStringEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IStringSpecificationValidationBuilder<T> should_be();
        IStringSpecificationValidationBuilder<T> should_not_be();
    }
}