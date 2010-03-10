using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using Validation.Mapping.ValidationBuilders;
using Validation.UnitTests.Stubs;
using Validation.Validation.Validators;

namespace Validation.UnitTests.Mapping.Builders
{
    public abstract class object_validation_builder_concern
    {
        Establish c = () =>
            {
                validators = new List<IValidator<Cat>>();
                ignore_validators = new HashSet<IgnoreValidator>();
            };
        protected static IList<IValidator<Cat>> validators;
        protected static HashSet<IgnoreValidator> ignore_validators;
    }
		
    [Subject("Ignoring an object property")]
    public class when_asked_to_ignore_an_object_property : object_validation_builder_concern
    {
        Establish c = () =>
            {
                ignore_validator = new IgnoreValidator(typeof(Cat).AssemblyQualifiedName,"fights_with",typeof(Dog).AssemblyQualifiedName);
                expression = x => x.fights_with;
                
                object_validation_builder = new ObjectValidationBuilder<Cat>(expression, validators,ignore_validators);
            };
			
        Because b = () =>
            {
                object_validation_builder.ignore();
            };

        It should_add_an_IgnoreValidator_to_the_list_of_ignore_validators = () =>
            {
                object_validation_builder.ignore_validators.ShouldContain(ignore_validator);
            };
        
        static Expression<Func<Cat, object>> expression;
        static ObjectValidationBuilder<Cat> object_validation_builder;
        static IgnoreValidator ignore_validator;
    }
}
