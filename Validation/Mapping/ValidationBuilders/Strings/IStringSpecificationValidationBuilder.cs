using System.Text.RegularExpressions;
using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Strings
{
    public interface IStringSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> equal_to(string value);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> equal_to(int value);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> greater_than(int value);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> greater_than_or_equal_to(int value);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> less_than(int value);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> less_than_or_equal_to(int value);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> not_null();
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> not_empty();
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_that_matches(Regex pattern);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing(string value);
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing_at_least_1_capital_letter();
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing_at_least_1_lowercase_letter();
        IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing_at_least_1_number();
    }
}