using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Objects
{
    public interface IObjectSpecificationValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IObjectEntryValidationBuilder<T>> equal_to(object value);
        IFailureEntryValidationBuilder<T, IObjectEntryValidationBuilder<T>> Null();
    }
}