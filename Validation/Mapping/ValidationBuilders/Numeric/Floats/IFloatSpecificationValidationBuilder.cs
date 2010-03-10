using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Numeric.Floats
{
    public interface IFloatSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IFloatEntryValidationBuilder<T>> equal_to(float value);
        IFailureEntryValidationBuilder<T, IFloatEntryValidationBuilder<T>> greater_than(float value);
        IFailureEntryValidationBuilder<T, IFloatEntryValidationBuilder<T>> greater_than_zero();
        IFailureEntryValidationBuilder<T, IFloatEntryValidationBuilder<T>> less_than(float value);
        BetweenValidationBuilder<T, IFloatEntryValidationBuilder<T>,float> between(float lower, float upper);
    }
}