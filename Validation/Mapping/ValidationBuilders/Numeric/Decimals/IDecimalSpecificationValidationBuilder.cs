using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Numeric.Decimals
{
    public interface IDecimalSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> equal_to(decimal value);
        IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> greater_than(decimal value);
        IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> greater_than_zero();
        IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> less_than(decimal value);
        BetweenValidationBuilder<T, IDecimalEntryValidationBuilder<T>,decimal> between(decimal lower, decimal upper);
    }
}