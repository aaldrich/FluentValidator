using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Numeric.Doubles
{
    public interface IDoubleSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> equal_to(double value);
        IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> greater_than(double value);
        IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> greater_than_or_equal_to(double value);
        IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> greater_than_zero();
        IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> less_than(double value);
        IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> less_than_or_equal_to(double value);
        BetweenValidationBuilder<T, IDoubleEntryValidationBuilder<T>,double> between(double lower, double upper);
    }
}