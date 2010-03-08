using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class not_validator_wrapper_concern
    {
        Establish c = () =>
        {
            greater_than_validator = new GreaterThanValidator<Cat, long>(x => x.id, 0);
            not_validator_wrapper =
                new NotValidatorWrapper<Cat, GreaterThanValidator<Cat, long>>(greater_than_validator);
        };

        static GreaterThanValidator<Cat, long> greater_than_validator;
        protected static NotValidatorWrapper<Cat, GreaterThanValidator<Cat, long>> not_validator_wrapper;
    }
		
    [Subject("Validating 1 is not greater than 0")]
    public class when_asked_if_1_is_not_greater_than_0 : not_validator_wrapper_concern
    {
        Because b = () =>
            result = not_validator_wrapper.Validate(new Cat{id = 1});

        It should_return_false = () =>
            result.ShouldBeFalse();

        static bool result;
    }

    [Subject("Validating -1 is not greater than 0")]
    public class when_asked_if_neg_1_is_not_greater_than_0 : not_validator_wrapper_concern
    {
        Because b = () =>
            result = not_validator_wrapper.Validate(new Cat{id = -1});

        It should_return_true = () =>
            result.ShouldBeTrue();

        static bool result;
    }

    [Subject("CustomFailureMessageStrategy is used upon creation")]
    public class when_creating_not_wrapper_validator : not_validator_wrapper_concern
    {
        It should_use_a_CustomFailureMessageStrategy_inserting_not_into_the_current_validators_failure_message = () =>
            not_validator_wrapper.failure_message.ShouldEqual("id must not be greater than 0");
    }
}
