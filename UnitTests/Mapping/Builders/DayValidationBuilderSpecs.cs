using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Validation.Mapping.ValidationBuilders;
using Validation.Mapping.ValidationBuilders.Dates.Days;
using Validation.Mapping.ValidationBuilders.Dates.Years;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Mapping.Builders
{
    public abstract class day_validation_builder_concern
    {
        protected static HashSet<IgnoreValidator> ignore_validators;		
    }

    [Subject("Specifiying a Day must be Friday")]
    public class when_specifiying_that_a_day_must_be_friday : day_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
            };

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date,validators,ignore_validators)
                        .should_be().equal_to().Friday();

        It should_add_a_dayofweek_equals_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<EqualsValidator<Cat, DayOfWeek>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> day_builder;

    }

    [Subject("Specifiying a Day must be greater than Friday")]
    public class when_specifiying_that_a_day_must_be_greater_than_friday : day_validation_builder_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date, validators,ignore_validators)
                          .should_be().greater_than().Friday();

        It should_add_a_dayofweek_greater_than_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<GreaterThanValidator<Cat, DayOfWeek>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> day_builder;
    }

    [Subject("Specifiying a Day must be less than Friday")]
    public class when_specifiying_that_a_day_must_be_less_than_friday : day_validation_builder_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date, validators,ignore_validators)
                         .should_be().less_than().Friday();

        It should_add_a_dayofweek_less_than_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<LessThanValidator<Cat, DayOfWeek>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> day_builder;
    }

    [Subject("Specifiying a day is between Monday and Friday")]
    public class when_specifiying_that_a_day_is_between_monday_and_friday : day_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
                current_builder = new ValidationBuilder<Cat>(validators,ignore_validators);
            };

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date,validators,ignore_validators)
                                      .should_be().between(DayOfWeek.Monday,DayOfWeek.Friday);

        It should_add_an_inclusive_between_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<InclusiveBetweenValidator<Cat, DayOfWeek>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> day_builder;
        static ValidationBuilder<Cat> current_builder;
    }

    [Subject("Specifiying a day is not greater than Monday")]
    public class when_specifiying_that_a_day_is_not_greater_than_monday : day_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
                current_builder = new ValidationBuilder<Cat>(validators,ignore_validators);
            };

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date,validators,ignore_validators)
                          .should_not_be().greater_than().Monday();

        It should_add_a_not_validator_wrapping_a_greater_than_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<NotValidatorWrapper<Cat,GreaterThanValidator<Cat, DayOfWeek>>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> current_builder;
        static IValidationBuilder<Cat> day_builder;
    }

    [Subject("Specifiying a Day must be the 30th")]
    public class when_specifiying_that_a_day_must_be_the_30th : day_validation_builder_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date, validators,ignore_validators)
                          .should_be().equal_to(30);

        It should_add_a_integer_equals_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<EqualsValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> day_builder;
    }

    [Subject("Specifiying a Day must be greater than the 30th")]
    public class when_specifiying_that_a_day_must_be_greater_than_the_30th : day_validation_builder_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date, validators,ignore_validators)
                          .should_be().greater_than(30);

        It should_add_an_integer_greater_than_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<GreaterThanValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> day_builder;
    }

    [Subject("Specifiying a Day must be less than the 30th")]
    public class when_specifiying_that_a_day_must_be_less_than_the_30th : day_validation_builder_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date, validators,ignore_validators)
                          .should_be().less_than(30);

        It should_add_an_integer_less_than_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<LessThanValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> day_builder;
    }

    [Subject("Specifiying a date between the 1st and the 30th")]
    public class when_specifiying_that_15th_is_between_1st_and_30th : day_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
                current_builder = new ValidationBuilder<Cat>(validators,ignore_validators);
            };

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date, validators,ignore_validators)
                          .should_be().between(1, 30);

        It should_add_an_inclusive_between_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<InclusiveBetweenValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> day_builder;
        static ValidationBuilder<Cat> current_builder;
    }

    [Subject("Specifiying a day is not greater than Monday")]
    public class when_specifiying_that_a_day_is_not_greater_than_the_30th : day_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
                current_builder = new ValidationBuilder<Cat>(validators,ignore_validators);
            };

        Because b = () =>
            day_builder = new DayValidationBuilder<Cat>(x => x.birth_date, validators,ignore_validators)
                          .should_not_be().greater_than(30);

        It should_add_a_not_validator_wrapping_a_greater_than_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<NotValidatorWrapper<Cat, GreaterThanValidator<Cat, int>>>();

        static IList<IValidator<Cat>> validators;
        static IValidationBuilder<Cat> current_builder;
        static IValidationBuilder<Cat> day_builder;
    }
}