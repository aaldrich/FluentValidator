using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric
{
    public class DecimalValidationBuilder<T>: ValidationBuilder<T>
    {
        readonly Expression<Func<T, decimal>> expression;

        public DecimalValidationBuilder(Expression<Func<T,decimal>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T,DecimalValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public CompositeValidationBuilder<T, DecimalValidationBuilder<T>> greater_than(decimal value)
        {
            var greater_than_validator = new GreaterThanValidator<T, decimal>(expression, value);
            validators.Add(greater_than_validator);
            return new CompositeValidationBuilder<T, DecimalValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, DecimalValidationBuilder<T>> not(decimal value)
        {
            var not_validator = new NotValidator<T, decimal>(expression, value);
            validators.Add(not_validator);
            return new CompositeValidationBuilder<T,DecimalValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, DecimalValidationBuilder<T>> should_be(decimal value)
        {
            var equals_validator = new EqualsValidator<T, decimal>(expression, value);
            validators.Add(equals_validator);
            return new CompositeValidationBuilder<T, DecimalValidationBuilder<T>>(this);
        }



        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,DecimalValidationBuilder<T>,decimal> between(decimal lower, decimal upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, decimal>(expression, lower, upper);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, DecimalValidationBuilder<T>,decimal>(expression,inclusive_validator,this,lower,upper);
        }
    }
}