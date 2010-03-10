using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Strings
{
    public partial class StringValidationBuilder<T> : CanWrapWithNotValidationBuilder<T>,
                                              IStringEntryValidationBuilder<T>,
                                              IStringSpecificationValidationBuilder<T>
                                              where T : class
    {
        readonly Expression<Func<T, string>> expression;

        public StringValidationBuilder(Expression<Func<T, string>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }
        
        public IStringSpecificationValidationBuilder<T> should_be()
        {
            return this;
        }

        public IStringSpecificationValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }
    }
}