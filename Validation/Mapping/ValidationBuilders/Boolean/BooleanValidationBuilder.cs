using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Boolean
{
    public class BooleanValidationBuilder<T>: ValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, bool>> expression;

        public BooleanValidationBuilder(Expression<Func<T, bool>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IFailureEntryValidationBuilder<T,BooleanValidationBuilder<T>> should_be_true()
        {
            return boolean_validate(true);
        }

        public IFailureEntryValidationBuilder<T, BooleanValidationBuilder<T>> should_be_false()
        {
            return boolean_validate(false);
        }

        IFailureEntryValidationBuilder<T, BooleanValidationBuilder<T>> boolean_validate(bool value)
        {
            var boolean_validator = new BooleanValidator<T, bool>(expression, value);
            validators.Add(boolean_validator);
            return new FailureValidationBuilder<T,BooleanValidationBuilder<T>>(boolean_validator,validators,ignore_validators, this);
        }
    }
}