using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class inclusive_between_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.id;
                validator = new InclusiveBetweenValidator<Cat, long>(expression,5,10);
            };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, long>> expression;
        protected static InclusiveBetweenValidator<Cat, long> validator;
    }

    [Subject("Validating inclusive 6 is between 5 and 10")]
    public class when_validating_that_inclusive_6_is_between_5_and_10 : inclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat{id = 6};
			
        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating inclusive 4 is between 5 and 10")]
    public class when_validating_that_inclusive_4_is_between_5_and_10 : inclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 4 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating inclusive 11 is between 5 and 10")]
    public class when_validating_that_inclusive_11_is_between_5_and_10 : inclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 11 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating inclusive 5 is between 5 and 10")]
    public class when_validating_that_inclusive_5_is_between_5_and_10 : inclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 5 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating inclusive 10 is between 5 and 10")]
    public class when_validating_that_inclusive_10_is_between_5_and_10 : inclusive_between_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 10 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating a null value")]
    public class when_asking_inclusive_between_validator_to_validate_a_null_value : inclusive_between_validator_concern
    {
        Because b = () =>
            result = validator.Validate(null);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("ExpressionFailureMessageStrategy is used upon creation")]
    public class when_creating_inclusive_between_validator : inclusive_between_validator_concern
    {
        It should_use_a_ExpressionFailureMessageStrategy_as_the_default_failure_message_strategy = () =>
            validator.failure_message.ShouldEqual("id must be greater than or equal to 5 and less than or equal to 10");
    }
}