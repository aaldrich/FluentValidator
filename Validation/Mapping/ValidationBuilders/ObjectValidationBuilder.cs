using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Helpers;
using Validation.Mapping.ValidationBuilders.Finished;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class ObjectValidationBuilder<T> : ValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, object>> expression;

        public ObjectValidationBuilder(Expression<Func<T, object>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public ObjectValidationBuilder<T> not_null()
        {
            var validator = new NotNullValidator<T, object>(expression);
            validators.Add(validator);
            return this;
        }

        public IFinishedValidationBuilder ignore()
        {
            ignore_validators.Add(new IgnoreValidator(
                                    typeof(T).AssemblyQualifiedName,
                                    ExpressionHelper.GetMemberName(expression),
                                    ExpressionHelper.GetMemberType(expression).AssemblyQualifiedName));
            return new FinishedValidationBuilder();
        }
    }
}