using System;
using Machine.Specifications;
using Validation.Registry;
using Validation.UnitTests.Stubs;
using Validation.Validation;

namespace Validation.UnitTests.Validation
{
    public abstract class validator_concern
    {
        Establish c = () =>
            {
                ValidationRegistry.AddAssemblyFrom<CatMap>();
            };
    }
		
    [Subject("Validating a valid class")]
    public class when_asked_to_validate_a_valid_class : validator_concern
    {
        Establish c = () =>
            cat = new Cat { id = 1};
			
        Because b = () =>
            result = Validator.Validate(cat);	

        It should_return_true_if_all_validations_pass = () =>
            result.ShouldBeTrue();

        static Cat cat;
        static bool result;
    }

    [Subject("Validating a valid class")]
    public class when_asked_to_validate_an_invalid_class : validator_concern
    {
        Establish c = () =>
            cat = new Cat { id = 0 };

        Because b = () =>
            result = Validator.Validate(cat);

        It should_return_false_if_any_validations_fail = () =>
            result.ShouldBeFalse();

        static Cat cat;
        static bool result;
    }

    [Subject("Validating a class")]
    public class when_asked_to_validate_a_null_class : validator_concern
    {
        Because b = () =>
        {
            try
            {
                result = Validator.Validate(cat);
            }
            catch (ArgumentNullException ex)
            {
                exception = ex;
            }
        };

        It should_throw_a_null_argument_exception = () =>
            exception.ShouldNotBeNull();

        static Cat cat;
        static bool result;
        static ArgumentNullException exception = null;
    }
}
