using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.Mapping.ValidationBuilders;
using Validation.Mapping.ValidationBuilders.Numeric;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Mapping
{
    public abstract class long_property_part_concern
    {
		
    }
		
    [Subject("Specifiying a Long is greater than 0")]
    public class when_specifiying_that_a_long_must_be_greater_than_0 : long_property_part_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            long_builder = new LongValidationBuilder<Cat>(x=>x.id,validators)
            .greater_than_zero();

        It should_add_the_greater_than_validation_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<GreaterThanValidator<Cat, long>>();

        static ValidationBuilder<Cat> long_builder;
        static IList<IValidator<Cat>> validators;
    }

    [Subject("Specifiying a Long is greater than negative 1")]
    public class when_specifiying_that_a_long_must_be_greater_than_neg_1 : long_property_part_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            long_builder = new LongValidationBuilder<Cat>(x => x.id, validators)
            .greater_than(-1);

        It should_add_the_greater_than_validation_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<GreaterThanValidator<Cat, long>>();

        static ValidationBuilder<Cat> long_builder;
        static IList<IValidator<Cat>> validators;
    }

    [Subject("Specifying the long is between a range")]
    public class when_specifying_that_a_long_must_be_between_a_range_of_values : long_property_part_concern
    {
        Establish c = () =>
            validators = new List<IValidator<Cat>>();

        Because b = () =>
            long_builder = new LongValidationBuilder<Cat>(x => x.id, validators)
            .between(1, 10);

        It should_add_an_inclusive_between_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<InclusiveBetweenValidator<Cat,long>>();

        static IList<IValidator<Cat>> validators;
        static ValidationBuilder<Cat> long_builder;
    }
}
