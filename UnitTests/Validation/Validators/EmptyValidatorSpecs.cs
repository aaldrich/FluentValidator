using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class empty_validator_concern
    {
        Establish c = () =>
            {
                expression = x => x.name;
                validator = new EmptyValidator<Cat, string>(expression);
            };

        protected static Cat oliver_the_cat;
        protected static bool result;
        static Expression<Func<Cat, string>> expression;
        protected static EmptyValidator<Cat, string> validator;
    }

    [Subject("Validating non empty object is not empty ")]
    public class when_validating_that_a_non_empty_string_is_not_empty : empty_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat{name = "oliver"};
			
        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating empty object is not empty")]
    public class when_validating_that_a_empty_string_is_not_empty : empty_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { name = String.Empty };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    public abstract class empty_list_validator_concern : empty_validator_concern
    {
        Establish c = () =>
        {
            expression = x => x.kittens;
            validator = new EmptyValidator<Cat, IList<Cat>>(expression);
        };

        static Expression<Func<Cat, IList<Cat> >> expression;
        new protected static EmptyValidator<Cat, IList<Cat>> validator;
    }

    [Subject("Validating empty list is not empty")]
    public class when_validating_that_a_empty_list_is_not_empty : empty_list_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { kittens =  new List<Cat>()};

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }

    [Subject("Validating non empty list is not empty")]
    public class when_validating_that_a_non_empty_list_is_not_empty : empty_list_validator_concern
    {
        Establish c = () =>
            oliver_the_cat = new Cat { kittens = new List<Cat>(){new Cat()} };

        Because b = () =>
            result = validator.Validate(oliver_the_cat);

        It should_return_true = () =>
            result.ShouldBeTrue();
    }

    [Subject("Validating a null value")]
    public class when_asking_empty_validator_to_validate_a_null_value : empty_list_validator_concern
    {
        Because b = () =>
            result = validator.Validate(null);

        It should_return_false = () =>
            result.ShouldBeFalse();
    }
}