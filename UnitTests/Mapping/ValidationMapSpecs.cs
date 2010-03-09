using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using Validation.Mapping.ValidationBuilders;
using Validation.Mapping.ValidationBuilders.Numeric.Longs;
using Validation.Mapping.ValidationMappers;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;
using It=Machine.Specifications.It;

namespace Validation.UnitTests.Mapping
{
    public abstract class validation_map_concern
    {
        Establish c = () =>
            {
                cat_mapper = new ValidationMap<Cat>();
                validators = new List<IValidator<Cat>> { new Mock<IValidator<Cat>>().Object };
            };

        protected static ValidationMap<Cat> cat_mapper;
        protected static List<IValidator<Cat>> validators;
    }

    [Subject("Mapping a long property")]
    public class when_mapping_a_long_property_type : validation_map_concern
    {
        Because b = () =>
            mapper = cat_mapper.Map(x => x.id);

        It should_return_a_numeric_property_part = () =>
            mapper.ShouldBeOfType<LongValidationBuilder<Cat>>();

        static ILongEntryValidationBuilder<Cat> mapper;
    }

    [Subject("Mapping a string property")]
    public class when_mapping_a_string_property_type : validation_map_concern
    {
        Because b = () =>
            mapper = cat_mapper.Map(x => x.name);

        It should_return_a_string_property_part = () =>
            mapper.ShouldBeOfType<StringValidationBuilder<Cat>>();

        static StringValidationBuilder<Cat> mapper;
    }

    [Subject("Mapping a object property")]
    public class when_mapping_a_object_property_type : validation_map_concern
    {
        Because b = () =>
            mapper = cat_mapper.Map(x => x);

        It should_return_a_object_property_part = () =>
            mapper.ShouldBeOfType<ObjectValidationBuilder<Cat>>();

        static ObjectValidationBuilder<Cat> mapper;
    }

}