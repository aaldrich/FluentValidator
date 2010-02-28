using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.Helpers;
using Validation.Mapping;
using Validation.UnitTests.Stubs;

namespace Validation.UnitTests.Helpers
{
    public abstract class expression_helper_concern
    {
		
    }

    [Subject("Getting Property Type from Expression<Func<T,object>>")]
    public class when_getting_property_type_given_an_expression_func_t_object : expression_helper_concern
    {
        Establish c = () =>
            expression = x=>x.id;
			
        Because b = () =>
            type = ExpressionHelper.GetPropertyType(expression);	

        It should_return_the_type_of_the_object_parameter = () =>
            type.FullName.ShouldEqual(typeof(long).FullName);

        static Expression<Func<Cat, object>> expression;
        static Type type;
    }
}