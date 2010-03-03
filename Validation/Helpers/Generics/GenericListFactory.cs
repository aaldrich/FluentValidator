using System;
using System.Collections.Generic;

namespace Validation.Helpers.Generics
{
    public class GenericListFactory : IGenericListFactory
    {
        public GenericList create(Type list_type, object list_instance)
        {
            var list = typeof(List<>).MakeGenericType(list_type);
            var count = GenericList.get_count(list, list_instance);
            IList<object> items = new List<object>();

            for (int i = 0; i < count; i++)
            {
                items.Add(GenericList.get_item(list, list_instance, i));
            }
            
            return new GenericList {count = count, items = items};
        }
    }

    public interface IGenericListFactory
    {
        GenericList create(Type list_type, object list_instance);
    }
}