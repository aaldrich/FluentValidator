using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class regex_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.name; 
            };

        protected static Expression<Func<Cat, string>> expression;
        protected static RegexValidator<Cat> regex_validator;
        protected static Cat oliver;
    }
		
    [Subject("Regex validation for a capital letter")]
    public class when_validating_that_string_Oliver_contains_a_capital_letter : regex_validator_concern
    {
        Establish c = () =>
            {
                contains_capital_regex = new Regex("[A-Z]");
                oliver = new Cat() { name = "Oliver" };

                regex_validator = new RegexValidator<Cat>(expression, contains_capital_regex);
            };
			
        Because b = () =>
            {
                result = regex_validator.Validate(oliver);
            };

        It should_return_true = () =>
            {
                result.ShouldBeTrue();
            };

        static Regex contains_capital_regex;
        static bool result;
    }

    [Subject("Regex validation for a lowercase letter")]
    public class when_validating_that_string_Oliver_contains_a_lower_case_letter : regex_validator_concern
    {
        Establish c = () =>
        {
            contains_capital_regex = new Regex("[a-z]");
            oliver = new Cat() { name = "Oliver" };

            regex_validator = new RegexValidator<Cat>(expression, contains_capital_regex);
        };

        Because b = () =>
        {
            result = regex_validator.Validate(oliver);
        };

        It should_return_true = () =>
        {
            result.ShouldBeTrue();
        };

        static Regex contains_capital_regex;
        static bool result;
    }

    [Subject("Regex validation for an number")]
    public class when_validating_that_string_Oliver1_contains_a_number : regex_validator_concern
    {
        Establish c = () =>
        {
            contains_capital_regex = new Regex("[0-9]");
            oliver = new Cat() { name = "Oliver1" };

            regex_validator = new RegexValidator<Cat>(expression, contains_capital_regex);
        };

        Because b = () =>
        {
            result = regex_validator.Validate(oliver);
        };

        It should_return_true = () =>
        {
            result.ShouldBeTrue();
        };

        static Regex contains_capital_regex;
        static bool result;
    }

    [Subject("ExpressionFailureMessageStrategy is used upon creation")]
    public class when_creating_regex_validator : regex_validator_concern
    {
        Establish c = () =>
            {
                contains_capital_regex = new Regex("[0-9]");
                oliver = new Cat() { name = "Oliver1" };
            };

        Because b = () =>
            {
                regex_validator = new RegexValidator<Cat>(expression, contains_capital_regex);
            };

        It should_use_a_ExpressionFailureMessageStrategy_as_the_default_failure_message_strategy = () =>
            regex_validator.failure_message.ShouldEqual("name must be a value matching pattern " + contains_capital_regex.ToString());

        static Regex contains_capital_regex;
    }
}
