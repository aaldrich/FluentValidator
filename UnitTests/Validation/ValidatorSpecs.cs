using System;
using Machine.Specifications;
using Validation.Registry;
using Validation.UnitTests.Stubs;
using Validation.Validation;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation
{
    public abstract class validator_concern
    {
        Establish c = () =>
            {
                ValidationRegistry.AddAssemblyFrom<CatMap>();
                ValidationRegistry.AddAssemblyFrom<DogMap>();
                ValidationRegistry.Configure();

                greater_than_validator = new GreaterThanValidator<Cat,long>(x=>x.id,0);
                failing_validator_result = new ValidatorResult{failure_message = greater_than_validator.failure_message,successful = false};
            };

        static GreaterThanValidator<Cat, long> greater_than_validator;
        protected static ValidatorResult failing_validator_result;

        protected static Cat valid_cat()
        {
            return new Cat() {id = 1, birth_date = new DateTime(2005,06,07)};
        }

        protected static Cat invalid_cat()
        {
            return new Cat() {id = 0}; 
        }

        protected static Dog valid_dog()
        {
            return new Dog() {id = 1, fights_with = new Cat()};
        }
    }

    [Subject("Validating a valid class")]
    public class when_asked_to_validate_a_valid_class : validator_concern
    {
        Establish c = () =>
            cat = valid_cat(); 
			
        Because b = () =>
            result = Validator.Validate(cat);	

        It should_return_true_if_all_validations_pass = () =>
            result.successful.ShouldBeTrue();

        static Cat cat;
        static ValidationResult result;
    }

    [Subject("Validating a valid class")]
    public class when_asked_to_validate_an_invalid_class : validator_concern
    {
        Establish c = () =>
            {
                cat = invalid_cat();
            }; 

        Because b = () =>
            result = Validator.Validate(cat);

        It should_return_false_if_any_validations_fail = () =>
            result.successful.ShouldBeFalse();

        It should_return_all_the_validation_result_failures = () =>
            result.validator_failures.ShouldContain(failing_validator_result);

        static Cat cat;
        static ValidationResult result;
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
        static ValidationResult result;
        static ArgumentNullException exception = null;
    }

    [Subject("When Validating a class with another type of class that has a mapping")]
    public class when_validating_a_class_with_another_type_of_class_property : validator_concern
    {
        Establish context = () =>
            {
                cat = invalid_cat();
                dog = valid_dog();
                dog.fights_with = cat;
            };

        Because of = () =>
            result = Validator.Validate(dog);

        It should_validate_the_other_class_as_well = () =>
            result.successful.ShouldBeFalse(); //Since cat is invalid it should not validate dog

        It should_return_the_invalid_validators_in_the_result = () =>
            result.validator_failures.ShouldContain(failing_validator_result);

        static Dog dog;
        static ValidationResult result;
        static Cat cat;
    }
}
