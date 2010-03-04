using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Validation.Mapping.ValidationBuilders;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Mapping
{
    public abstract class month_validation_builder_concern
    {
		
    }
		
    [Subject("Specifiying a Month must be january")]
    public class when_specifiying_that_a_month_must_be_january : month_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
                current_builder = new ValidationBuilder<Cat>(validators);
            };

        Because b = () =>
            month_builder = new MonthValidationBuilder<Cat,ValidationBuilder<Cat>>(x => x.birth_date,current_builder)
            .should_be().equal_to().January();

        It should_add_an_integer_equals_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<EqualsValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> month_builder;
        static ValidationBuilder<Cat> current_builder;
    }

    [Subject("Specifiying June is between January and July")]
    public class when_specifiying_that_june_is_between_january_and_july : month_validation_builder_concern
    {
        Establish c = () =>
        {
            validators = new List<IValidator<Cat>>();
            current_builder = new ValidationBuilder<Cat>(validators);
        };

        Because b = () =>
            month_builder = new MonthValidationBuilder<Cat, ValidationBuilder<Cat>>(x => x.birth_date, current_builder)
            .should_be().between(Month.January,Month.July);

        It should_add_an_inclusive_between_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<InclusiveBetweenValidator<Cat, int>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> month_builder;
        static ValidationBuilder<Cat> current_builder;
    }
}
