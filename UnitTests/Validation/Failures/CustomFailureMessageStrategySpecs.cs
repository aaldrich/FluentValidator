using System;
using Machine.Specifications;
using Validation.Validation.Failures;

namespace Validation.UnitTests.Validation.Failures
{
    public abstract class custom_failure_message_strategy_concern
    {
		
    }
		
    [Subject("Getting Failure message from Custom Failure Message Strategy")]
    public class when_asked_for_the_failure_message : custom_failure_message_strategy_concern
    {
        Establish c = () =>
            {
                message = "Awesome!";
                custom_failure_message_strategy = new CustomFailureMessageStrategy(message);
            };

        Because b = () =>
            result = custom_failure_message_strategy.get_failure_message();

        It should_use_the_custom_message_given_in_the_constructor = () =>
            result.ShouldEqual(message);

        static string message;
        static CustomFailureMessageStrategy custom_failure_message_strategy;
        static string result;
    }

    [Subject("Getting Failure message from Custom Failure Message Strategy")]
    public class when_asked_for_the_failure_message_when_given_a_null : custom_failure_message_strategy_concern
    {
        Establish c = () =>
            custom_failure_message_strategy = new CustomFailureMessageStrategy(null);

        Because b = () =>
            result = custom_failure_message_strategy.get_failure_message();

        It should_return_an_empty_string = () =>
            result.ShouldEqual(String.Empty);

        static CustomFailureMessageStrategy custom_failure_message_strategy;
        static string result;
    }
}
