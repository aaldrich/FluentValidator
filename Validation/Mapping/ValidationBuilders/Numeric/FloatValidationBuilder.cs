using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric
{
    public class FloatValidationBuilder<T>: ValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, float>> expression;

        public FloatValidationBuilder(Expression<Func<T,float>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T,FloatValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public CompositeValidationBuilder<T, FloatValidationBuilder<T>> greater_than(float value)
        {
            var greater_than_validator = new GreaterThanValidator<T, float>(expression, value);
            validators.Add(greater_than_validator);
            return new CompositeValidationBuilder<T, FloatValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, FloatValidationBuilder<T>> not(float value)
        {
            var not_validator = new NotValidator<T, float>(expression, value);
            validators.Add(not_validator);
            return new CompositeValidationBuilder<T,FloatValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, FloatValidationBuilder<T>> should_be(float value)
        {
            var equals_validator = new EqualsValidator<T, float>(expression, value);
            validators.Add(equals_validator);
            return new CompositeValidationBuilder<T, FloatValidationBuilder<T>>(this);
        }


        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,FloatValidationBuilder<T>,float> between(float lower, float upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, float>(expression, lower, upper);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, FloatValidationBuilder<T>,float>(expression,inclusive_validator,this,lower,upper);
        }
    }
}