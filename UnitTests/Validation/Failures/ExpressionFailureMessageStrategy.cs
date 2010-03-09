using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Failures;

namespace Validation.UnitTests.Validation.Failures
{
    public abstract class expression_failure_message_strategy_concern
    {
        Establish c = () =>
            {
                expression = x => x.id;
                validation_type = "greater than";
                expected_value = 0.ToString();
            };

        protected static Expression<Func<Cat, long>> expression;
        protected static string expected_value;
        protected static string validation_type;
    }
		
    [Subject("Getting Failure Message using expression failure message strategy")]
    public class when_asking_the_expression_failure_message_strategy_for_the_failure_message : expression_failure_message_strategy_concern
    {
        Establish c = () =>
            {
                strategy = new ExpressionFailureMessageStrategy(
                    expression.Body as MemberExpression, validation_type, expected_value);
            };
			
        Because b = () =>
            result = strategy.get_failure_message();

        It should_contain_the_member_expression_member_name = () =>
            result.Contains("id").ShouldBeTrue();

        It should_contain_the_validation_type = () =>
            result.Contains("greater than").ShouldBeTrue();

        It should_contain_the_expected_value = () =>
            result.Contains("0").ShouldBeTrue();
        

        static ExpressionFailureMessageStrategy strategy;
        static string result;
    }

    [Subject("Getting Failure Message using expression failure message strategy with null member expression")]
    public class when_asking_the_expression_failure_message_strategy_for_the_failure_message_but_member_expression_is_null : expression_failure_message_strategy_concern
    {
        Establish c = () =>
            strategy = new ExpressionFailureMessageStrategy(null, validation_type, expected_value);

        Because b = () =>
            result = strategy.get_failure_message();

        It should_return_an_empty_string = () =>
            result.ShouldBeEmpty();

        static ExpressionFailureMessageStrategy strategy;
        static string result;
    }

    [Subject("Getting Failure Message using expression failure message strategy with null validation_type")]
    public class when_asking_the_expression_failure_message_strategy_for_the_failure_message_but_validation_type_is_null : expression_failure_message_strategy_concern
    {
        Establish c = () =>
            strategy = new ExpressionFailureMessageStrategy(expression.Body as MemberExpression, null, expected_value);

        Because b = () =>
            result = strategy.get_failure_message();

        It should_return_an_empty_string = () =>
            result.ShouldBeEmpty();

        static ExpressionFailureMessageStrategy strategy;
        static string result;
    }

    [Subject("Getting Failure Message using expression failure message strategy with null expected value")]
    public class when_asking_the_expression_failure_message_strategy_for_the_failure_message_but_expected_value_is_null : expression_failure_message_strategy_concern
    {
        Establish c = () =>
            strategy = new ExpressionFailureMessageStrategy(expression.Body as MemberExpression, validation_type, null);

        Because b = () =>
            result = strategy.get_failure_message();

        It should_return_an_empty_string = () =>
            result.ShouldBeEmpty();

        static ExpressionFailureMessageStrategy strategy;
        static string result;
    }
}
