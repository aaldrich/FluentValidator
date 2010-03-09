using System;
using System.Collections.Generic;
using Validation.Validation.Failures;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Failure
{
    public class FailureValidationBuilder<T, TReturnBuilder> : ValidationBuilder<T>,
                                                               IFailureSpecificationValidationBuilder<T,TReturnBuilder>,
                                                               IFailureEntryValidationBuilder<T,TReturnBuilder>
        where TReturnBuilder : IValidationBuilder<T>
    {
        readonly IValidator<T> current_validator;
        readonly TReturnBuilder return_builder;

        public FailureValidationBuilder(
            IValidator<T> current_validator,
            IList<IValidator<T>> validators,
            TReturnBuilder return_builder)
            : base(validators)
        {
            this.current_validator = current_validator;
            this.return_builder = return_builder;
        }

        public IFailureSpecificationValidationBuilder<T, TReturnBuilder> upon_failure()
        {
            return this;
        }

        public TReturnBuilder and()
        {
            return return_builder;
        }

        public IFailureEntryValidationBuilder<T, TReturnBuilder> use_message(string message)
        {
            current_validator.failure_message_strategy = new CustomFailureMessageStrategy(message);
            return this;
        }

        public IFailureEntryValidationBuilder<T, TReturnBuilder> execute(Action<T> action)
        {
            current_validator.execute_upon_failure = action;
            return this;
        }
    }
}