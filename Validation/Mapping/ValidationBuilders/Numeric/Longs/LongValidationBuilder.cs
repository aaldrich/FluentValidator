using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric.Longs
{
    public class LongValidationBuilder<T>:  CanWrapWithNotValidationBuilder<T>,
                                            ILongEntryValidationBuilder<T>,
                                            ILongSpecificationValidationBuilder<T> where T : class

    {
        readonly Expression<Func<T, long>> expression;

        public LongValidationBuilder(Expression<Func<T,long>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> equal_to(long value)
        {
            var equal_to_validator = new EqualsValidator<T, long>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(equal_to_validator);
            return new FailureValidationBuilder<T,ILongEntryValidationBuilder<T>>(equal_to_validator,validators,this) ;
        }

        public IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> greater_than(long value)
        {
            var greater_than_validator = new GreaterThanValidator<T, long>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(greater_than_validator);
            return new FailureValidationBuilder<T, ILongEntryValidationBuilder<T>>(greater_than_validator,validators,this);
        }

        public IFailureEntryValidationBuilder<T, ILongEntryValidationBuilder<T>> less_than(long value)
        {
            var less_than_validator = new LessThanValidator<T, long>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(less_than_validator);
            return new FailureValidationBuilder<T, ILongEntryValidationBuilder<T>>(less_than_validator, validators, this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T, ILongEntryValidationBuilder<T>, long> between(long lower, long upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, long>(expression, lower, upper);

            base.add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, ILongEntryValidationBuilder<T>, long>(expression,inclusive_validator, this, lower, upper);
        }

        public ILongSpecificationValidationBuilder<T> should_be()
        {
            return this;
        }

        public ILongSpecificationValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }
    }
}