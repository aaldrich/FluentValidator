using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Validation.Mapping.ValidationBuilders;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Mapping.ValidationBuilders.Dates.Years;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Mapping.Builders
{
    public abstract class year_validation_builder_concern
    {
		
    }

    [Subject("Specifiying a Year must be 2010")]
    public class when_specifiying_that_a_year_must_be_2010 : year_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
                current_builder = new ValidationBuilder<Cat>(validators,ignore_validators);
            };

        Because b = () =>
                    year_builder = new YearValidationBuilder<Cat>(x => x.birth_date,current_builder.validators,ignore_validators)
                                       .should_be().equal_to(2010);

        It should_add_an_integer_equals_validator_to_the_list_of_validators = () =>
                                                                              validators.First().ShouldBeOfType<EqualsValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> year_builder;
        static ValidationBuilder<Cat> current_builder;
        static HashSet<IgnoreValidator> ignore_validators;
    }

    [Subject("Specifiying 2009 is between 2008 and 2010")]
    public class when_specifiying_that_2009_is_between_2008_and_2010 : month_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
            };

        Because b = () =>
                    year_builder = new YearValidationBuilder<Cat>(x => x.birth_date,validators,ignore_validators)
                                       .should_be().between(2008,2010);

        It should_add_an_inclusive_between_validator_to_the_list_of_validators = () =>
                                                                                 validators.First().ShouldBeOfType<InclusiveBetweenValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> year_builder;
    }

    [Subject("Specifiying 2010 is not greater than 2009")]
    public class when_specifiying_that_2010_is_not_greater_than_2009 : month_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
            };

        Because b = () =>
                    year_builder = new YearValidationBuilder<Cat>(x => x.birth_date,validators,ignore_validators)
                                       .should_not_be().greater_than(2009);

        It should_add_a_not_validator_wrapping_a_greater_than_validator_to_the_list_of_validators = () =>
                                                                                                    validators.First().ShouldBeOfType<NotValidatorWrapper<Cat,GreaterThanValidator<Cat, int>>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> year_builder;
    }
}