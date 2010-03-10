namespace Validation.Mapping.ValidationBuilders.Numeric.Integers
{
    public interface IIntegerEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IIntegerSpecificationValidationBuilder<T> should_be();
        IIntegerSpecificationValidationBuilder<T> should_not_be();
    }
}