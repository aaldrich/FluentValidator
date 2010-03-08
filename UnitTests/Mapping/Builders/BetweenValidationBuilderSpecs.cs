using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Machine.Specifications;
using Moq;
using Validation.Mapping.ValidationBuilders;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Mapping.Builders
{
    public abstract class between_builder_concern
    {
        Establish c = () =>
            {
                expression = x => x.id;
                inclusive_validator = new InclusiveBetweenValidator<Cat, long>(expression, 1, 10);
                validators = new List<IValidator<Cat>>() { inclusive_validator };
                validation_builder = new ValidationBuilder<Cat>(validators);
            };

        protected static InclusiveBetweenValidator<Cat, long> inclusive_validator;
        protected static Expression<Func<Cat, long>> expression;
        protected static ValidationBuilder<Cat> validation_builder;
        protected static IList<IValidator<Cat>> validators;
        
    }

    [Subject("Specifying that between validation should be exclusive")]
    public class when_specifying_that_between_should_be_exclusive : between_builder_concern
    {
        Establish c = () =>
            between_builder = new BetweenValidationBuilder<Cat, ValidationBuilder<Cat>, long>
                                  (expression, inclusive_validator, validation_builder, 1, 10);

        Because b = () =>
            between_builder.exclusive();

        It should_remove_the_inclusive_validator_from_the_list_of_validators = () =>
            validators.ShouldNotContain(inclusive_validator);
        
        It should_add_an_exclusive_between_validator_to_the_list_of_validators = () =>
            validators.First().ShouldBeOfType<ExclusiveBetweenValidator<Cat,long>>();

        static BetweenValidationBuilder<Cat, ValidationBuilder<Cat>, long> between_builder;
    }
}