using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class not_validator_wrapper_concern
    {
    }
		
    [Subject("Validating 1 is not greater than 0")]
    public class when_asked_if_1_is_not_greater_than_0 : not_validator_wrapper_concern
    {
        Establish c = () =>
            {
                greater_than_validator = new GreaterThanValidator<Cat, long>(x=>x.id,0);
                not_validator_wrapper = 
                    new NotValidatorWrapper<Cat, GreaterThanValidator<Cat, long>>(greater_than_validator);
            };
			
        Because b = () =>
            result = not_validator_wrapper.Validate(new Cat{id = 1});

        It should_return_false = () =>
            result.ShouldBeFalse();

        static GreaterThanValidator<Cat, long> greater_than_validator;
        static NotValidatorWrapper<Cat, GreaterThanValidator<Cat, long>> not_validator_wrapper;
        static bool result;
    }

    [Subject("Validating -1 is not greater than 0")]
    public class when_asked_if_neg_1_is_not_greater_than_0 : not_validator_wrapper_concern
    {
        Establish c = () =>
        {
            greater_than_validator = new GreaterThanValidator<Cat, long>(x => x.id, 0);
            not_validator_wrapper =
                new NotValidatorWrapper<Cat, GreaterThanValidator<Cat, long>>(greater_than_validator);
        };

        Because b = () =>
            result = not_validator_wrapper.Validate(new Cat{id = -1});

        It should_return_true = () =>
            result.ShouldBeTrue();

        static GreaterThanValidator<Cat, long> greater_than_validator;
        static NotValidatorWrapper<Cat, GreaterThanValidator<Cat, long>> not_validator_wrapper;
        static bool result;
    }
}
