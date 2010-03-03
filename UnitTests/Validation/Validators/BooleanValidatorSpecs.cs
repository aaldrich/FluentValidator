using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class bool_validator_concern
    {
        Establish c = () =>
        {
            expression = x => x.is_hungry;
            validator = new BooleanValidator<Cat, bool>(expression, true);
        };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, bool>> expression;
        protected static BooleanValidator<Cat, bool> validator;
    }

    [Subject("Validating false is not true")]
    public class when_validating_that_false_is_true : bool_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { is_hungry = false };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating true is true")]
    public class when_validating_that_true_is_true : bool_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { is_hungry = true};

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating a null value")]
    public class when_asking_boolean_validator_to_validate_a_null_value : bool_validator_concern
    {
        Because b = () =>
            result = validator.Validate(null);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }
}