namespace Validation.Mapping.ValidationBuilders.Numeric.Floats
{
    public interface IFloatEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IFloatSpecificationValidationBuilder<T> should_be();
        IFloatSpecificationValidationBuilder<T> should_not_be();
    }
}