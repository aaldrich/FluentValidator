using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class not_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.id;
                validator = new NotValidator<Cat, long>(expression, 0);
            };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, long>> expression;
        protected static NotValidator<Cat, long> validator;
    }

    public abstract class not_string_validator_concern
    {
        Establish c = () =>
        {
            expression = x => x.name;
            validator = new NotValidator<Cat, string>(expression, "cat");
        };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, string>> expression;
        protected static NotValidator<Cat, string> validator;
    }

    [Subject("Validating -1 is not 0")]
    public class when_validating_that_neg_1_is_not_0 : not_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat{id = -1};
			
        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating 0 is not 0")]
    public class when_validating_that_0_is_not_0 : not_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { id = 0 };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating cat string is not dog string")]
    public class when_validating_that_string_cat_is_not_string_dog : not_string_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { name = "dog" };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating a null value")]
    public class when_asking_not_validator_to_validate_a_null_value : not_validator_concern
    {
        Because b = () =>
            result = validator.Validate(null);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("ExpressionFailureMessageStrategy is used upon creation")]
    public class when_creating_not_validator : not_validator_concern
    {
        It should_use_a_ExpressionFailureMessageStrategy_as_the_default_failure_message_strategy = () =>
            validator.failure_message.ShouldEqual("id must be not equal to 0");
    }
}