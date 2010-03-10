using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Helpers;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Mapping.ValidationBuilders.Finished;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Objects
{
    public class ObjectValidationBuilder<T> : CanWrapWithNotValidationBuilder<T>,
                                              IObjectEntryValidationBuilder<T>,
                                              IObjectSpecificationValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, object>> expression;

        public ObjectValidationBuilder(Expression<Func<T, object>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IFinishedValidationBuilder ignore_my_validations()
        {
            ignore_validators.Add(new IgnoreValidator(
                                      typeof(T).AssemblyQualifiedName,
                                      ExpressionHelper.GetMemberName(expression),
                                      ExpressionHelper.GetMemberType(expression).AssemblyQualifiedName));
            return new FinishedValidationBuilder();
        }

        public IObjectSpecificationValidationBuilder<T> should_be()
        {
            return this; 
        }

        public IObjectSpecificationValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }

        public IFailureEntryValidationBuilder<T, IObjectEntryValidationBuilder<T>> equal_to(object value)
        {
            var validator = new EqualsValidator<T, object>(get_null_object_wrapper(), value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IObjectEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IObjectEntryValidationBuilder<T>> Null()
        {
            var validator = new NullValidator<T, object>(expression);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IObjectEntryValidationBuilder<T>>(validator, validators, ignore_validators, this); 
        }

        BinaryExpression get_null_coalesce_expression()
        {
            Expression<Func<T, object>> empty_object = (x => new object());
            return Expression.Coalesce(expression.Body, empty_object.Body);
        }

        Expression<Func<T, object>> get_null_object_wrapper()
        {
            Expression null_wrapper = get_null_coalesce_expression();

            var func = Expression.Lambda<Func<T, object>>(null_wrapper, expression.Parameters);
            return func;
        }
    }
}