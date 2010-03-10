namespace Validation.Mapping.ValidationBuilders.Numeric.Doubles
{
    public interface IDoubleEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IDoubleSpecificationValidationBuilder<T> should_be();
        IDoubleSpecificationValidationBuilder<T> should_not_be();
    }
}