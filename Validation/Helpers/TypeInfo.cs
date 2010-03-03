using System;
using System.Reflection;

namespace Validation.Helpers
{
    public class TypeInfo
    {
        public Type type;
        public PropertyInfo property_info;

        public bool Equals(TypeInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.type, type) && Equals(other.property_info, property_info);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TypeInfo)) return false;
            return Equals((TypeInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((type != null ? type.GetHashCode() : 0)*397) ^ (property_info != null ? property_info.GetHashCode() : 0);
            }
        }
    }
}