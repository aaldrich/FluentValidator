using System;

namespace Validation.Mapping.ValidationBuilders.Failure
{
    public interface IFailureSpecificationValidationBuilder<T, TReturnBuilder> 
        where TReturnBuilder : IValidationBuilder<T>
    {
        IFailureEntryValidationBuilder<T,TReturnBuilder> use_message(string message);
        IFailureEntryValidationBuilder<T, TReturnBuilder> execute(Action<T> action);
    }
}