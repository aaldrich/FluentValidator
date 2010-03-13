using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Numeric.Longs
{
    public interface ILongSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> equal_to(long value);
        IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> greater_than(long value);
        IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> greater_than_or_equal_to(long value);
        IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> greater_than_zero();
        IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> less_than(long value);
        IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> less_than_or_equal_to(long value);
        BetweenValidationBuilder<T, ILongEntryValidationBuilder<T>,long> between(long lower, long upper);
    }
}