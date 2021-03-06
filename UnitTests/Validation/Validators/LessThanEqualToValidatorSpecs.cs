using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class less_than_equal_to_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.id;
                validator = new LessThanEqualToValidator<Cat, long>(expression, 0);
            };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, long>> expression;
        protected static LessThanEqualToValidator<Cat, long> validator;
    }

    [Subject("Validating -1 is less than or equal to 0")]
    public class when_validating_that_neg_1_is_less_than_or_equal_to_0 : less_than_equal_to_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat{id = -1};
			
        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating 0 is less than or equal to 0")]
    public class when_validating_that_0_is_less_than_or_equal_to_0 : less_than_equal_to_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 0 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating 1 is less than or equal to 0")]
    public class when_validating_that_1_is_less_than_or_equal_to_0 : less_than_equal_to_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 1 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating a null value")]
    public class when_asking_less_than_equal_to_validator_to_validate_a_null_value : less_than_equal_to_validator_concern
    {
        Because b = () =>
            result = validator.Validate(null);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("ExpressionFailureMessageStrategy is used upon creation")]
    public class when_creating_less_than_or_equal_to_validator : less_than_equal_to_validator_concern
    {
        It should_use_a_ExpressionFailureMessageStrategy_as_the_default_failure_message_strategy = () =>
            validator.failure_message.ShouldEqual("id must be less than or equal to 0");
    }
}