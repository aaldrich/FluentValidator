namespace Validation.Mapping.ValidationBuilders
{
    public class IgnoreValidator
    {
        readonly string assembly_qualified_parent_class_name;
        readonly string property_name;
        readonly string assembly_qualified_child_class_name;

        public IgnoreValidator(string assembly_qualified_parent_class_name, string property_name, string assembly_qualified_child_class_name)
        {
            this.assembly_qualified_parent_class_name = assembly_qualified_parent_class_name;
            this.property_name = property_name;
            this.assembly_qualified_child_class_name = assembly_qualified_child_class_name;
        }

        public bool Equals(IgnoreValidator other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.assembly_qualified_parent_class_name, assembly_qualified_parent_class_name) && Equals(other.property_name, property_name) && Equals(other.assembly_qualified_child_class_name, assembly_qualified_child_class_name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (IgnoreValidator)) return false;
            return Equals((IgnoreValidator) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (assembly_qualified_parent_class_name != null ? assembly_qualified_parent_class_name.GetHashCode() : 0);
                result = (result*397) ^ (property_name != null ? property_name.GetHashCode() : 0);
                result = (result*397) ^ (assembly_qualified_child_class_name != null ? assembly_qualified_child_class_name.GetHashCode() : 0);
                return result;
            }
        }
    }
}