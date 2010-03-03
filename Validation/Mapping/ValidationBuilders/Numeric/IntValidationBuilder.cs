using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric
{
    public class IntValidationBuilder<T>: ValidationBuilder<T>
    {
        readonly Expression<Func<T, int>> expression;

        public IntValidationBuilder(Expression<Func<T,int>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T,IntValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public CompositeValidationBuilder<T, IntValidationBuilder<T>> greater_than(int value)
        {
            var greater_than_validator = new GreaterThanValidator<T, int>(expression, value);
            validators.Add(greater_than_validator);
            return new CompositeValidationBuilder<T, IntValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, IntValidationBuilder<T>> not(int value)
        {
            var not_validator = new NotValidator<T, int>(expression, value);
            validators.Add(not_validator);
            return new CompositeValidationBuilder<T,IntValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, IntValidationBuilder<T>> should_be(int value)
        {
            var equals_validator = new EqualsValidator<T, int>(expression, value);
            validators.Add(equals_validator);
            return new CompositeValidationBuilder<T, IntValidationBuilder<T>>(this);
        }


        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,IntValidationBuilder<T>,int> between(int lower, int upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, int>(expression, lower, upper);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, IntValidationBuilder<T>,int>(expression,inclusive_validator,this,lower,upper);
        }

    }
}