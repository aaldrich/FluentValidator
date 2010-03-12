using System;
using System.Text.RegularExpressions;
using Validation.Mapping.ValidationMappers;

namespace Validation.UnitTests.Stubs
{
    public class CatMap : ValidationMap<Cat>
    {
        public CatMap()
        {
            Map(x => x.birth_date).date()
                .should_be()
                .between(new DateTime(2004, 01, 01), new DateTime(2009, 01, 01))
                .upon_failure().use_message("blah");
            Map(x => x.birth_date).year().should_be().between(2004, 2009);
            Map(x => x.birth_date).year().should_be().greater_than(2003);
            Map(x => x.birth_date).day().should_be().equal_to(7);
            Map(x => x.birth_date).day().should_be().equal_to().Tuesday();
            

            Map(x => x.id).should_be().greater_than(0);
            Map(x => x.fights_with).ignore_my_validations();

            Map(x => x.name).should_be().greater_than(0)
                .and().should_be().a_value_containing_at_least_1_capital_letter()
                .and().should_be().a_value_containing_at_least_1_number()
                .and().should_be().a_value_containing_at_least_1_lowercase_letter()
                .and().should_be().a_value_that_matches(new Regex("[A-Z]"));

            Map(x => x.fights_with).should_be().Null();
        }
    }
}
