using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class string_contains_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.name;
            };

        protected static Expression<Func<Cat, string>> expression;
    }
		
    [Subject("Validating a string contains a value")]
    public class when_validating_that_oliver_contains_olive : string_contains_validator_concern
    {
        Establish c = () =>
            {
                oliver = new Cat { name = "oliver" };
                
                contains_validator = new StringContainsValidator<Cat>(expression, "olive");
            };
			
        Because b = () =>
            {
                result = contains_validator.Validate(oliver);
            };

        It should_return_true = () =>
            {
                result.ShouldBeTrue();
            };

        static StringContainsValidator<Cat> contains_validator;
        static Cat oliver;
        static bool result;
    }

    [Subject("Validating a string contains a value")]
    public class when_validating_that_oliver_contains_adam : string_contains_validator_concern
    {
        Establish c = () =>
        {
            oliver = new Cat { name = "oliver" };

            contains_validator = new StringContainsValidator<Cat>(expression, "adam");
        };

        Because b = () =>
        {
            result = contains_validator.Validate(oliver);
        };

        It should_return_false = () =>
        {
            result.ShouldBeFalse();
        };

        static StringContainsValidator<Cat> contains_validator;
        static Cat oliver;
        static bool result;
    }

    [Subject("Validating a string contains a value")]
    public class when_validating_that_oliver_contains_null : string_contains_validator_concern
    {
        Establish c = () =>
        {
            oliver = new Cat { name = "oliver" };

            Expression<Func<Cat, string>> expression = x => x.name;
        };

        Because b = () =>
        {
            try
            {
                contains_validator = new StringContainsValidator<Cat>(expression, null);
            }
            catch (ArgumentNullException ex)
            {
                exception = ex;
            }
        };

        It should_throw_arguement_null_exception = () =>
        {
            exception.ShouldBeOfType<ArgumentNullException>();
        };

        static StringContainsValidator<Cat> contains_validator;
        static Cat oliver;
        static bool result;
        static ArgumentNullException exception;
    }

    [Subject("ExpressionFailureMessageStrategy is used upon creation")]
    public class when_creating_string_contains_validator : string_contains_validator_concern
    {
        Establish c = () =>
        {
            oliver = new Cat { name = "oliver" };
        };

        Because b = () =>
        {
            contains_validator = new StringContainsValidator<Cat>(expression, "olive");
        };

        It should_use_a_ExpressionFailureMessageStrategy_as_the_default_failure_message_strategy = () =>
            contains_validator.failure_message.ShouldEqual("name must be a value containing olive");

        static StringContainsValidator<Cat> contains_validator;
        static Cat oliver;
    }
}
