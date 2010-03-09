using System;
using System.Collections.Generic;
using Machine.Specifications;
using Validation.Mapping.ValidationBuilders;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.UnitTests.Stubs;
using Validation.Validation.Failures;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Mapping.Builders
{
    public abstract class failure_validation_concern
    {
        Establish c = () =>
            {
                current_validator = new EqualsValidator<Cat, long>(x => x.id, 1);
                validators = new List<IValidator<Cat>>{current_validator};
                failure_validation_builder 
                    = new FailureValidationBuilder<Cat,ValidationBuilder<Cat>>(current_validator,validators,return_builder);
            };

        protected static EqualsValidator<Cat, long> current_validator;
        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> return_builder;
        protected static FailureValidationBuilder<Cat, ValidationBuilder<Cat>> failure_validation_builder;
    }
		
    [Subject("Using a specific message upon failure")]
    public class when_asked_to_use_a_specific_message_upon_failure : failure_validation_concern
    {
        Because b = () =>
            failure_validation_builder.use_message("Awesome!");

        It should_set_the_validator_failure_message_strategy_to_a_custom_strategy = () =>
            current_validator.failure_message_strategy.ShouldBeOfType<CustomFailureMessageStrategy>();

        It should_return_the_given_message_when_the_failure_message_is_asked_for = () =>
            current_validator.failure_message_strategy.get_failure_message().ShouldEqual("Awesome!");

    }

    [Subject("Setting Executing action upon failure")]
    public class when_asked_to_execute_an_action_upon_failure : failure_validation_concern
    {
        Establish c = () =>
            action = x => x.id = 42;

        Because b = () =>
            failure_validation_builder.execute(action);

        It should_set_the_validators_failure_execute_to_the_given_action = () =>
            current_validator.execute_upon_failure.ShouldEqual(action);

        static Action<Cat> action;
    }

    [Subject("Executing an action upon failure")]
    public class when_executing_an_action_upon_failure : failure_validation_concern
    {
        Establish c = () =>
            {
                action = x => x.id = 42;
                failure_validation_builder.execute(action);

                cat = new Cat { id = 0 };
            };

        Because b = () =>
            result = current_validator.Validate(cat); 

        It should_execute_the_given_action = () =>
            cat.id.ShouldEqual(42);

        It should_return_false = () =>
            result.ShouldBeFalse();

        static Action<Cat> action;
        static Cat cat;
        static bool result;
    }

    [Subject("Executing a null action upon failure")]
    public class when_executing_a_null_action_upon_failure : failure_validation_concern
    {
        Establish c = () =>
        {
            action = null;
            failure_validation_builder.execute(action);

            cat = new Cat { id = 0 };
        };

        Because b = () =>
            result = current_validator.Validate(cat);

        It should_return_false = () =>
            result.ShouldBeFalse();

        static Action<Cat> action;
        static Cat cat;
        static bool result;
    }
}
