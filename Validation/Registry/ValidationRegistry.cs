using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validation.Mapping.ValidationMappers;

namespace Validation.Registry
{
    public static class ValidationRegistry
    {
        static IList<Assembly> scan_assemblies;

        static ValidationRegistry()
        {
            scan_assemblies = new List<Assembly>(); 
        }

        public static void AddAssemblyFrom<T>()
        {
            var assembly = typeof(T).Assembly;

            if (!scan_assemblies.Contains(assembly))
                scan_assemblies.Add(typeof(T).Assembly);
        }

        public static IEnumerable<Assembly> get_scan_assemblies()
        {
            return scan_assemblies;
        }

        //static IEnumerable<IValidationMap> get_validation_maps()
        //{
        //    IEnumerable<Type> types = get_validation_maps_from_assemblies();

        //    foreach (var type in types)
        //    {
        //        object instance = create_instance_from_type(type);
        //        yield return (IValidationMap)instance;
        //    }
        //}

        static object create_instance_from_type(Type type)
        {
            var real_type = Type.GetType(type.AssemblyQualifiedName);
            return Activator.CreateInstance(real_type);
        }

        static IEnumerable<Type> get_validation_maps_from_assemblies()
        {
            return scan_assemblies .SelectMany(x => x.GetTypes())
                .Where(x=>x.IsClass)
                .Where(x=>x.BaseType.Name.Equals(typeof(ValidationMap<>).Name))
                .Where(typeof(IValidationMap).IsAssignableFrom);
        }

        public static ValidationMap<T> GetMapFor<T>()
        {
            IEnumerable<Type> maps = get_validation_map_for_type<T>();
            
            var instance = create_instance_from_type(maps.First());

            return instance as ValidationMap<T>;
        }

        static IEnumerable<Type> get_validation_map_for_type<T>()
        {
            return scan_assemblies.SelectMany(x => x.GetTypes())
                .Where(x=>x.IsClass)
                .Where(x=>x.BaseType.FullName.Equals(typeof(ValidationMap<T>).FullName))
                .Where(typeof(IValidationMap).IsAssignableFrom);
        }

        public static void IsValid()
        {
            
            var maps = get_validation_maps_from_assemblies();

            var group = maps.GroupBy(x => x.FullName);

            //if (maps.Count() > 1)
            //    throw new AmbiguousMatchException("Multiple maps exist for the generic type " + typeof(T).Name);

        }
    }
}