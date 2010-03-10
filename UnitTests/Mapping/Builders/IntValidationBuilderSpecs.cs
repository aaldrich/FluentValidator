using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.Mapping.ValidationBuilders;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Mapping.ValidationBuilders.Numeric.Integers;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Mapping.Builders
{
    public abstract class int_validation_builder_concern
    {
		
    }

    [Subject("Specifiying a Int is greater than 0")]
    public class when_specifiying_that_a_int_must_be_greater_than_0 :int_validation_builder_concern 
    {
        Establish c = () =>
                      validators = new List<IValidator<Cat>>();

        Because b = () =>
                    int_builder = new IntValidationBuilder<Cat>(x=>x.birth_date.Month,validators,ignore_validators)
                                      .greater_than_zero();

        It should_add_the_greater_than_validation_to_the_list_of_validators = () =>
                                                                              validators.First().ShouldBeOfType<GreaterThanValidator<Cat, int>>();

        static IFailureEntryValidationBuilder<Cat, IIntegerEntryValidationBuilder<Cat>> int_builder;
        static IList<IValidator<Cat>> validators;
        static HashSet<IgnoreValidator> ignore_validators;
    }
}