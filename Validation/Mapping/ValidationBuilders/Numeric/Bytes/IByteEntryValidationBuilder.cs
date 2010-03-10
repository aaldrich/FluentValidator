namespace Validation.Mapping.ValidationBuilders.Numeric.Bytes
{
    public interface IByteEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IByteSpecificationValidationBuilder<T> should_be();
        IByteSpecificationValidationBuilder<T> should_not_be();
    }
}