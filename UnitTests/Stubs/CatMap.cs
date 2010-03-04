using Validation.Mapping.ValidationBuilders.Date;
using Validation.Mapping.ValidationBuilders.Dates.Months;
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
            Map(x => x.birth_date).month().should_be().between(Month.January,Month.July);
        }
    }
}