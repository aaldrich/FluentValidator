using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Validation.Validators
{
    public abstract class collection_contains_validator_concern
    {
        Establish c = () =>
            {
                timmy = new Cat { name = "timmy" };
                oliver = new Cat {name="oliver", kittens = new List<Cat> { timmy } };
       
                expression = x => x.kittens;
            };
        
        protected static Cat oliver;
        protected static Cat timmy;
        protected static Expression<Func<Cat, IEnumerable<Cat>>> expression;
    }
		
    [Subject("Validating an enumerable contains a value")]
    public class when_validating_that_enumerable_list_of_kittens_contains_the_specified_cat : collection_contains_validator_concern
    {
        Establish c = () =>
            {
                contains_validator = new CollectionContainsValidator<Cat, Cat>(expression, timmy);
            };
			
        Because b = () =>
            {
                result = contains_validator.Validate(oliver);
            };

        It should_return_true = () =>
            {
                result.ShouldBeTrue();
            };

        static CollectionContainsValidator<Cat, Cat> contains_validator;
        static bool result;
    }

    [Subject("ExpressionFailureMessageStrategy is used upon creation")]
    public class when_creating_collection_contains_validator : collection_contains_validator_concern
    {
        Because b = () =>
            contains_validator = new CollectionContainsValidator<Cat,Cat>(expression, timmy);

        It should_use_a_ExpressionFailureMessageStrategy_as_the_default_failure_message_strategy = () =>
            contains_validator.failure_message.ShouldEqual("kittens must be a value containing " + timmy.ToString());

        static CollectionContainsValidator<Cat, Cat> contains_validator;
    }
}
