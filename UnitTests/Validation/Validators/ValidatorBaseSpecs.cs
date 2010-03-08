using Machine.Specifications;
using Moq;
using Validation.UnitTests.Stubs;
using Validation.Validation.Failures;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class validator_base_specs
    {
        Establish c = () =>
            {
                message = "Awesome!";
                failure_message_strategy = new Mock<IFailureMessageStrategy>();
                failure_message_strategy.Setup(x => x.get_failure_message()).Returns(message);
            };

        protected static string message;
        protected static Mock<IFailureMessageStrategy> failure_message_strategy;
    }
		
    [Subject("Getting failure message without setting a custom one")]
    public class when_getting_the_failure_message_from_the_validator : validator_base_specs
    {
        Establish c = () =>
            validator_base = new ValidatorBase<Cat>();

        Because b = () =>
            validator_base.failure_message_strategy = failure_message_strategy.Object; 

        It should_use_the_failure_message_strategy_to_get_the_message = () =>
            validator_base.failure_message.ShouldEqual(message);

        static ValidatorBase<Cat> validator_base;
    }
}
