using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric
{
    public class LongValidationBuilder<T>: ValidationBuilder<T>
    {
        readonly Expression<Func<T, long>> expression;

        public LongValidationBuilder(Expression<Func<T,long>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T,LongValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public CompositeValidationBuilder<T, LongValidationBuilder<T>> greater_than(long value)
        {
            var greater_than_validator = new GreaterThanValidator<T, long>(expression, value);
            validators.Add(greater_than_validator);
            return new CompositeValidationBuilder<T, LongValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, LongValidationBuilder<T>> not(long value)
        {
            var not_validator = new NotValidator<T, long>(expression, value);
            validators.Add(not_validator);
            return new CompositeValidationBuilder<T,LongValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, LongValidationBuilder<T>> should_be(long value)
        {
            var equals_validator = new EqualsValidator<T, long>(expression, value);
            validators.Add(equals_validator);
            return new CompositeValidationBuilder<T, LongValidationBuilder<T>>(this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,LongValidationBuilder<T>,long> between(long lower, long upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, long>(expression, lower, upper);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, LongValidationBuilder<T>,long>(expression,inclusive_validator,this,lower,upper);
        }

    }
}