using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric.Doubles
{
    public class DoubleValidationBuilder<T>:  CanWrapWithNotValidationBuilder<T>,
                                            IDoubleEntryValidationBuilder<T>,
                                            IDoubleSpecificationValidationBuilder<T> where T : class

    {
        readonly Expression<Func<T, double>> expression;

        public DoubleValidationBuilder(Expression<Func<T,double>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> equal_to(double value)
        {
            var equal_to_validator = new EqualsValidator<T, double>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(equal_to_validator);
            return new FailureValidationBuilder<T,IDoubleEntryValidationBuilder<T>>(equal_to_validator,validators,ignore_validators,this) ;
        }

        public IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> greater_than(double value)
        {
            var greater_than_validator = new GreaterThanValidator<T, double>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(greater_than_validator);
            return new FailureValidationBuilder<T, IDoubleEntryValidationBuilder<T>>(greater_than_validator,validators,ignore_validators,this);
        }

        public IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> greater_than_or_equal_to(double value)
        {
            var greater_than_equal_to_validator = new GreaterThanEqualToValidator<T, double>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(greater_than_equal_to_validator);
            return new FailureValidationBuilder<T, IDoubleEntryValidationBuilder<T>>(greater_than_equal_to_validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> less_than(double value)
        {
            var less_than_validator = new LessThanValidator<T, double>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(less_than_validator);
            return new FailureValidationBuilder<T, IDoubleEntryValidationBuilder<T>>(less_than_validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IDoubleEntryValidationBuilder<T>> less_than_or_equal_to(double value)
        {
            var less_than_equal_to_validator = new LessThanEqualToValidator<T, double>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(less_than_equal_to_validator);
            return new FailureValidationBuilder<T, IDoubleEntryValidationBuilder<T>>(less_than_equal_to_validator, validators, ignore_validators, this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T, IDoubleEntryValidationBuilder<T>, double> between(double lower, double upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, double>(expression, lower, upper);

            base.add_validator_with_not_wrapper_if_needed(inclusive_validator);

            return new BetweenValidationBuilder<T, IDoubleEntryValidationBuilder<T>, double>(expression,inclusive_validator, this, lower, upper);
        }

        public IDoubleSpecificationValidationBuilder<T> should_be()
        {
            return this;
        }

        public IDoubleSpecificationValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }
    }
}