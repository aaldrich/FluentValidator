using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric.Bytes
{
    public class ByteValidationBuilder<T>:  CanWrapWithNotValidationBuilder<T>,
                                            IByteEntryValidationBuilder<T>,
                                            IByteSpecificationValidationBuilder<T> where T : class

    {
        readonly Expression<Func<T, byte>> expression;

        public ByteValidationBuilder(Expression<Func<T,byte>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> equal_to(byte value)
        {
            var equal_to_validator = new EqualsValidator<T, byte>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(equal_to_validator);
            return new FailureValidationBuilder<T,IByteEntryValidationBuilder<T>>(equal_to_validator,validators,ignore_validators,this) ;
        }

        public IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> greater_than(byte value)
        {
            var greater_than_validator = new GreaterThanValidator<T, byte>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(greater_than_validator);
            return new FailureValidationBuilder<T, IByteEntryValidationBuilder<T>>(greater_than_validator,validators,ignore_validators,this);
        }

        public IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> greater_than_or_equal_to(byte value)
        {
            var greater_than_validator = new GreaterThanEqualToValidator<T, byte>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(greater_than_validator);
            return new FailureValidationBuilder<T, IByteEntryValidationBuilder<T>>(greater_than_validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> less_than(byte value)
        {
            var less_than_validator = new LessThanValidator<T, byte>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(less_than_validator);
            return new FailureValidationBuilder<T, IByteEntryValidationBuilder<T>>(less_than_validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IByteEntryValidationBuilder<T>> less_than_or_equal_to(byte value)
        {
            var less_than_validator = new LessThanEqualToValidator<T, byte>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(less_than_validator);
            return new FailureValidationBuilder<T, IByteEntryValidationBuilder<T>>(less_than_validator, validators, ignore_validators, this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T, IByteEntryValidationBuilder<T>, byte> between(byte lower, byte upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, byte>(expression, lower, upper);

            base.add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, IByteEntryValidationBuilder<T>, byte>(expression,inclusive_validator, this, lower, upper);
        }

        public IByteSpecificationValidationBuilder<T> should_be()
        {
            return this;
        }

        public IByteSpecificationValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }
    }
}