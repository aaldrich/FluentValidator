namespace Validation.Mapping.ValidationBuilders.Numeric.Longs
{
    public interface ILongEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        ILongSpecificationValidationBuilder<T> should_be();
        ILongSpecificationValidationBuilder<T> should_not_be();
    }
}