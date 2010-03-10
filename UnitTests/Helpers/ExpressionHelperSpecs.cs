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

    [Subject("Getting Property Name from Expression<Func<Cat,object>>")]
    public class when_getting_property_name_given_an_expression_func_Cat_object : expression_helper_concern
    {
        Establish c = () =>
            expression = x=>x.id;
			
        Because b = () =>
            name = ExpressionHelper.GetMemberName(expression);	

        It should_return_the_name_of_the_object_parameter = () =>
            name.ShouldEqual("id");

        static Expression<Func<Cat, object>> expression;
        static string name;
    }

    [Subject("Getting Property Type from Expression<Func<Cat,object>>")]
    public class when_getting_property_type_given_an_expression_func_Cat_object : expression_helper_concern
    {
        Establish c = () =>
            expression = x => x.id;

        Because b = () =>
            type = ExpressionHelper.GetMemberType(expression);

        It should_return_the_type_of_the_object_parameter = () =>
            type.ShouldEqual(typeof(long));

        static Expression<Func<Cat, object>> expression;
        static Type type;
    }

    [Subject("Getting Property Type from Expression<Func<Cat,long>>")]
    public class when_getting_property_type_given_an_expression_func_Cat_long : expression_helper_concern
    {
        Establish c = () =>
            expression = x => x.id;

        Because b = () =>
            type = ExpressionHelper.GetMemberType(expression);

        It should_return_the_type_of_the_long_parameter = () =>
            type.ShouldEqual(typeof(long));

        static Expression<Func<Cat, long>> expression;
        static Type type;
    }

    [Subject("Getting Property Name from Expression<Func<Cat,object>>")]
    public class when_getting_property_name_given_an_expression_func_Cat_long : expression_helper_concern
    {
        Establish c = () =>
            expression = x => x.id;

        Because b = () =>
            name = ExpressionHelper.GetMemberName(expression);

        It should_return_the_name_of_the_long_parameter = () =>
            name.ShouldEqual("id");

        static Expression<Func<Cat, long>> expression;
        static string name;
    }


}