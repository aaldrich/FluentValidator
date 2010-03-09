using System;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Mapping.ValidationMappers;

namespace Validation.UnitTests.Stubs
{
    public class CatMap : ValidationMap<Cat>
    {
        public CatMap()
        {
            Map(x => x.birth_date).date().should_be().between(new DateTime(2004, 01, 01), new DateTime(2009, 01, 01));
            Map(x => x.id).should_be().greater_than(0).upon_failure().use_message("blah");
        }
    }
}
