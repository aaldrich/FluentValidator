using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class null_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.name;
                validator = new NotNullValidator<Cat, string>(expression);
            };

        protected static Cat oliver_the_cat;
        protected static bool result;
        protected static Expression<Func<Cat, string>> expression;
        protected static NotNullValidator<Cat, string> validator;
    }

    [Subject("Validating non null object is not null")]
    public class when_validating_that_non_null_object_is_not_null : null_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat{name = "oliver"};
			
        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating non null object is not null")]
    public class when_validating_that_null_object_is_not_null : null_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { name = null };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating a null value")]
    public class when_asking_null_validator_to_validate_a_null_instance : null_validator_concern
    {
        Because b = () =>
            result = validator.Validate(null);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("ExpressionFailureMessageStrategy is used upon creation")]
    public class when_creating_null_validator : null_validator_concern
    {
        It should_use_a_ExpressionFailureMessageStrategy_as_the_default_failure_message_strategy = () =>
            validator.failure_message.ShouldEqual("name must be non null");
    }
}