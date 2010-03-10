using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Numeric.Integers
{
    public interface IIntegerSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IIntegerEntryValidationBuilder<T>> equal_to(int value);
        IFailureEntryValidationBuilder<T, IIntegerEntryValidationBuilder<T>> greater_than(int value);
        IFailureEntryValidationBuilder<T, IIntegerEntryValidationBuilder<T>> greater_than_zero();
        IFailureEntryValidationBuilder<T, IIntegerEntryValidationBuilder<T>> less_than(int value);
        BetweenValidationBuilder<T, IIntegerEntryValidationBuilder<T>,int> between(int lower, int upper);
    }
}