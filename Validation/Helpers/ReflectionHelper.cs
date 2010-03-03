using System;
using System.Collections.Generic;
using System.Linq;

namespace Validation.Helpers
{
    public class ReflectionHelper
    {
        public static IEnumerable<TypeInfo> get_class_properties_for<T>() where T : class
        {
            var types = typeof(T).GetProperties()
                .Where(x => x.PropertyType.IsClass)
                .Select(x => new TypeInfo { property_info = x, type = x.PropertyType});

            return types;
        }

        public static object create_instance_from_type(Type type)
        {
            var real_type = Type.GetType(type.AssemblyQualifiedName);
            return Activator.CreateInstance(real_type);
        }
    }
}