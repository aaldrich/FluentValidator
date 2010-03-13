using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Numeric.Bytes
{
    public interface IByteSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> equal_to(byte value);
        IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> greater_than(byte value);
        IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> greater_than_or_equal_to(byte value);
        IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> greater_than_zero();
        IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> less_than(byte value);
        IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> less_than_or_equal_to(byte value);
        BetweenValidationBuilder<T, IByteEntryValidationBuilder<T>,byte> between(byte lower, byte upper);
    }
}