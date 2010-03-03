using System;
using System.Collections;
using System.Collections.Generic;

namespace Validation.Helpers.Generics
{
    public class GenericList : IEnumerable
    {
        public int count { get; internal set;}
        public IList<object> items { get; internal set; }
        
        public GenericList()
        {
            count = 0;
            items = new List<object>();
        }

        internal static object get_item(Type generic_list, object list_instance, int index)
        {
            return generic_list.GetMethod("get_Item")
                .Invoke(list_instance, new object[] { index });
        }

        internal static int get_count(Type generic_list, object list_instance)
        {
            return (int)generic_list.GetMethod("get_Count").Invoke(list_instance, null);
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator(); 
        }
    }
}