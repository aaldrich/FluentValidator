using System;
using System.Collections.Generic;
using Machine.Specifications;
using Validation.Helpers;
using Validation.Mapping.ValidationMappers;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Helpers
{
    public abstract class reflection_helper_concern
    {
		
    }

    [Subject("Getting all object properties from a class")]
    public class when_asking_for_all_properties_of_a_class_that_are_an_object : reflection_helper_concern
    {
        Establish c = () =>
            cat_type_info = new TypeInfo() { type = typeof(Cat), property_info = typeof(Dog).GetProperty("fights_with")};

        Because b = () =>
            properties = ReflectionHelper.get_class_properties_for<Dog>();

        It should_return_all_the_property_types_that_are_objects = () =>
            properties.ShouldContainOnly(cat_type_info);

        static Dog dog;
        static IEnumerable<TypeInfo> properties;
        static TypeInfo cat_type_info;
    }

    [Subject("Creating a generic ValidationMap")]
    public class when_asked_to_create_a_generic_validation_map_from_the_assembly_qualified_name
    {
        Because of = () =>
            validation_map = ReflectionHelper.create_generic_ValidationMap(typeof(Cat).AssemblyQualifiedName);

        It should_return_a_Type_that_is_an_ValidationMap = () =>
            validation_map.Equals(typeof(ValidationMap<Cat>)).ShouldBeTrue();

        static Type validation_map;
    }
}