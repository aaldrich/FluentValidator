using Validation.Mapping.ValidationBuilders.Finished;

namespace Validation.Mapping.ValidationBuilders.Objects
{
    public interface IObjectEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IObjectSpecificationValidationBuilder<T> should_be();
        IObjectSpecificationValidationBuilder<T> should_not_be();
        IFinishedValidationBuilder ignore_my_validations();
    }
}