using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validation.Helpers;
using Validation.Mapping.ValidationMappers;

namespace Validation.Registry
{
    public static class ValidationRegistry
    {
        static IList<Assembly> scan_assemblies;
        public static IDictionary<string,object> validation_maps;

        static ValidationRegistry()
        {
            scan_assemblies = new List<Assembly>(); 
            validation_maps = new Dictionary<string, object>();
        }

        public static void Configure()
        {
            validation_maps = new Dictionary<string, object>();
            add_validation_maps();
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
        
        static void add_validation_maps()
        {
            foreach (var assembly in scan_assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(x => typeof(IValidationMap).IsAssignableFrom(x));
                    
                foreach (var type in types)
                {
                    var instance = ReflectionHelper.create_instance_from_type(type) as IValidationMap; 
                    validation_maps.Add(instance.ValidationType.AssemblyQualifiedName,instance);
                }
            } 
        }

        public static void IsValid()
        {
            
            //var maps = get_validation_maps_from_assemblies();

            //var group = maps.GroupBy(x => x.FullName);

            ////if (maps.Count() > 1)
            //    throw new AmbiguousMatchException("Multiple maps exist for the generic type " + typeof(T).Name);

        }

        public static ValidationMap<T> GetMapFor<T>() where T : class
        {
            var map = (ValidationMap<T>) validation_maps.
                                          First(x => x.Key.Equals(typeof (T).AssemblyQualifiedName))
                                          .Value;
            return map;
        }
    }
}