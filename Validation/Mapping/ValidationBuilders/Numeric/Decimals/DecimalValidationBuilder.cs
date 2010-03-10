using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric.Decimals
{
    public class DecimalValidationBuilder<T>:  CanWrapWithNotValidationBuilder<T>,
                                            IDecimalEntryValidationBuilder<T>,
                                            IDecimalSpecificationValidationBuilder<T> where T : class

    {
        readonly Expression<Func<T, decimal>> expression;

        public DecimalValidationBuilder(Expression<Func<T,decimal>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> equal_to(decimal value)
        {
            var equal_to_validator = new EqualsValidator<T, decimal>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(equal_to_validator);
            return new FailureValidationBuilder<T,IDecimalEntryValidationBuilder<T>>(equal_to_validator,validators,ignore_validators,this) ;
        }

        public IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> greater_than(decimal value)
        {
            var greater_than_validator = new GreaterThanValidator<T, decimal>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(greater_than_validator);
            return new FailureValidationBuilder<T, IDecimalEntryValidationBuilder<T>>(greater_than_validator,validators,ignore_validators,this);
        }

        public IFailureEntryValidationBuilder<T, IDecimalEntryValidationBuilder<T>> less_than(decimal value)
        {
            var less_than_validator = new LessThanValidator<T, decimal>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(less_than_validator);
            return new FailureValidationBuilder<T, IDecimalEntryValidationBuilder<T>>(less_than_validator, validators, ignore_validators, this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T, IDecimalEntryValidationBuilder<T>, decimal> between(decimal lower, decimal upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, decimal>(expression, lower, upper);

            base.add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, IDecimalEntryValidationBuilder<T>, decimal>(expression,inclusive_validator, this, lower, upper);
        }

        public IDecimalSpecificationValidationBuilder<T> should_be()
        {
            return this;
        }

        public IDecimalSpecificationValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }
    }
}