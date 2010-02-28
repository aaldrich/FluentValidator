using System;
using System.Collections.Generic;
using System.Linq;

namespace Validation.Helpers
{
    public class ReflectionHelper
    {
        public static IEnumerable<string> get_class_properties_for<T>() where T : class
        {
            var types = typeof (T).GetProperties()
                .Where(x => x.PropertyType.IsClass)
                .Select(x => x.PropertyType.AssemblyQualifiedName);

            return types;
        }
    }
}