using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric
{
    public class DoubleValidationBuilder<T>: ValidationBuilder<T>
    {
        readonly Expression<Func<T, double>> expression;

        public DoubleValidationBuilder(Expression<Func<T,double>> expression, IList<IValidator<T>> validators)
            : base(validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T,DoubleValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public CompositeValidationBuilder<T, DoubleValidationBuilder<T>> greater_than(double value)
        {
            var greater_than_validator = new GreaterThanValidator<T, double>(expression, value);
            validators.Add(greater_than_validator);
            return new CompositeValidationBuilder<T, DoubleValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, DoubleValidationBuilder<T>> not(double value)
        {
            var not_validator = new NotValidator<T, double>(expression, value);
            validators.Add(not_validator);
            return new CompositeValidationBuilder<T,DoubleValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, DoubleValidationBuilder<T>> should_be(double value)
        {
            var equals_validator = new EqualsValidator<T, double>(expression, value);
            validators.Add(equals_validator);
            return new CompositeValidationBuilder<T, DoubleValidationBuilder<T>>(this);
        }


        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,DoubleValidationBuilder<T>,double> between(double lower, double upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, double>(expression, lower, upper);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, DoubleValidationBuilder<T>,double>(expression,inclusive_validator,this,lower,upper);
        }
    }
}