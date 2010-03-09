using System;
using Validation.Validation.Failures;

namespace Validation.Mapping.ValidationBuilders.Failure
{
    public interface IFailureEntryValidationBuilder<T, TReturnBuilder> : IValidationBuilder<T>
        where TReturnBuilder : IValidationBuilder<T>
    {
        IFailureSpecificationValidationBuilder<T, TReturnBuilder> upon_failure();
        TReturnBuilder and();
    }
}