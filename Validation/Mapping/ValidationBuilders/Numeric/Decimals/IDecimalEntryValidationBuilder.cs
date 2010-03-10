namespace Validation.Mapping.ValidationBuilders.Numeric.Decimals
{
    public interface IDecimalEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IDecimalSpecificationValidationBuilder<T> should_be();
        IDecimalSpecificationValidationBuilder<T> should_not_be();
    }
}