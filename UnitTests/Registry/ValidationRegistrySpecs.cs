using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Machine.Specifications;
using Validation.Mapping.ValidationMappers;
using Validation.Registry;
using Validation.UnitTests.Stubs;

namespace Validation.UnitTests.Registry
{
    public abstract class validation_registry_concern
    {
    }
		
    [Subject("Pulling Assembly from Type")]
    public class when_given_a_type_to_pull_assembly_from : validation_registry_concern
    {
        Because b = () =>
            ValidationRegistry.AddAssemblyFrom<Cat>();

        It should_store_the_assembly_into_the_scan_assemblies = () =>
            ValidationRegistry.get_scan_assemblies().ShouldContain(typeof(Cat).Assembly);
    }

    [Subject("Pulling Assembly from Type")]
    public class when_given_a_type_to_pull_assembly_from_and_the_assembly_has_already_been_added : validation_registry_concern
    {
        Because b = () =>
            {
                ValidationRegistry.AddAssemblyFrom<Cat>();
                ValidationRegistry.AddAssemblyFrom<Cat>();
            };

        It should_not_add_duplicate_assemblies_to_the_scan_assemblies = () =>
            ValidationRegistry.get_scan_assemblies().Count().ShouldEqual(1);
    }

    //[Subject("Getting all classes that inherit ValidationMap")]
    //public class when_asked_for_all_the_validation_maps : validation_registry_concern
    //{
    //    Establish c = () =>
    //        ValidationRegistry.AddAssemblyFrom<CatMap>();
        
    //    Because b = () =>
    //        maps = ValidationRegistry.get_validation_maps();

    //    It should_return_all_the_classes_that_inherit_from_validationmap = () =>
    //        maps.First().ShouldBeOfType<CatMap>(); 

    //    static IEnumerable<IValidationMap> maps;
    //}

    //[Subject("Getting Validation Map for specified type")]
    //public class when_asked_for_a_validation_map_for_the_specified_type : validation_registry_concern
    //{
    //    Establish c = () =>
    //        {
    //            ValidationRegistry.AddAssemblyFrom<CatMap>();
    //            ValidationRegistry.Configure();
    //        };

    //    Because b = () =>
    //        map = ValidationRegistry.GetMapFor<Cat>();

    //    It should_return_the_validation_map_instance_for_the_given_type = () =>
    //        map.ShouldBeOfType<CatMap>();

    //    static ValidationMap<Cat> map;
    //}

    [Subject("Validating Registry for only 1 validation map for a type")]
    [Ignore]
    public class when_validating_the_registry_with_multiple_maps_for_a_given_type : validation_registry_concern
    {
        Establish c = () =>
                ValidationRegistry.AddAssemblyFrom<CatMap>();

        Because b = () =>
            {
                try
                {
                    ValidationRegistry.IsValid();
                }
                catch (AmbiguousMatchException ex)
                {
                    exception = ex;
                }
            };

        It should_throw_a_AmbiguousMatchException = () =>
            exception.ShouldNotBeNull();

        static AmbiguousMatchException exception;
    }
}
