using Validation.Mapping.ValidationMappers;

namespace Validation.UnitTests.Stubs
{
    public class CatMap : ValidationMap<Cat>
    {
        public CatMap()
        {
            Map(x => x.id).between(0, 10).exclusive()
                .and().greater_than_zero()
                .and().not(2);
        }
    }
}