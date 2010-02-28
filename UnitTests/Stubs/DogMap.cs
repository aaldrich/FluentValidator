using Validation.Mapping.ValidationMappers;

namespace Validation.UnitTests.Stubs
{
    public class DogMap : ValidationMap<Dog>
    {
        public DogMap()
        {
            Map(x => x.id).greater_than(0);
        } 
    }
}