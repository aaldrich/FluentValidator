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
                validator = new NullValidator<Cat, string>(expression);
            };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, string>> expression;
        protected static NullValidator<Cat, string> validator;
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
}