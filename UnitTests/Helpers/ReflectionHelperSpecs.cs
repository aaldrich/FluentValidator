using System;
using System.Collections.Generic;
using Machine.Specifications;
using Validation.Helpers;
using Validation.UnitTests.Stubs;

namespace Validation.UnitTests.Helpers
{
    public abstract class reflection_helper_concern
    {
		
    }

    [Subject("Getting all object properties from a class")]
    public class when_asking_for_all_properties_of_a_class_that_are_an_object : reflection_helper_concern
    {
        Because b = () =>
            properties = ReflectionHelper.get_class_properties_for<Dog>();

        It should_return_all_the_property_types_that_are_objects = () =>
            properties.ShouldContainOnly(typeof(Cat).AssemblyQualifiedName);

        static Dog dog;
        static IEnumerable<string> properties;
    }
}