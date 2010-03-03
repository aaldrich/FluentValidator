using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class exclusive_between_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.id;
                validator = new ExclusiveBetweenValidator<Cat, long>(expression,5,10);
            };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, long>> expression;
        protected static ExclusiveBetweenValidator<Cat, long> validator;
    }

    [Subject("Validating exclusive 6 is between 5 and 10")]
    public class when_validating_that_exclusive_6_is_between_5_and_10 : exclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat{id = 6};
			
        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating exclusive 4 is between 5 and 10")]
    public class when_validating_that_exclusive_4_is_between_5_and_10 : exclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 4 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating exclusive 11 is between 5 and 10")]
    public class when_validating_that_exclusive_11_is_between_5_and_10 : exclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 11 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating exclusive 5 is between 5 and 10")]
    public class when_validating_that_exclusive_5_is_between_5_and_10 : exclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 5 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating exclusive 10 is between 5 and 10")]
    public class when_validating_that_exclusive_10_is_between_5_and_10 : exclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 10 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating a null value")]
    public class when_asking_exclusive_between_validator_to_validate_a_null_value : exclusive_between_validator_concern
    {
        Because b = () =>
            result = validator.Validate(null);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }
}