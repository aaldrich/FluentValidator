using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Numeric
{
    public class ByteValidationBuilder<T>: ValidationBuilder<T> where T : class
    {
        readonly Expression<Func<T, byte>> expression;

        public ByteValidationBuilder(Expression<Func<T,byte>> expression, IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
            : base(validators,ignore_validators)
        {
            this.expression = expression;
        }

        public CompositeValidationBuilder<T,ByteValidationBuilder<T>> greater_than_zero()
        {
            return greater_than(0);
        }

        public CompositeValidationBuilder<T, ByteValidationBuilder<T>> greater_than(byte value)
        {
            var greater_than_validator = new GreaterThanValidator<T, byte>(expression, value);
            validators.Add(greater_than_validator);
            return new CompositeValidationBuilder<T, ByteValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, ByteValidationBuilder<T>> not(byte value)
        {
            var not_validator = new NotValidator<T, byte>(expression, value);
            validators.Add(not_validator);
            return new CompositeValidationBuilder<T,ByteValidationBuilder<T>>(this);
        }

        public CompositeValidationBuilder<T, ByteValidationBuilder<T>> should_be(byte value)
        {
            var equals_validator = new EqualsValidator<T, byte>(expression, value);
            validators.Add(equals_validator);
            return new CompositeValidationBuilder<T, ByteValidationBuilder<T>>(this);
        }

        /// <summary>
        /// Adds an Inclusive Between Validator. Inclusive uses equal to
        /// to determine the range. If you want to add an
        /// exclusive then use the exclusive chain after this method.
        /// </summary>
        /// <param name="lower">lower range (less than equal to)</param>
        /// <param name="upper">upper range (greather than equal to)</param>
        /// <returns>Between Validation Builder</returns>
        public BetweenValidationBuilder<T,ByteValidationBuilder<T>,byte> between(byte lower, byte upper)
        {
            var inclusive_validator =
                new InclusiveBetweenValidator<T, byte>(expression, lower, upper);

            validators.Add(inclusive_validator);
            return new BetweenValidationBuilder<T, ByteValidationBuilder<T>,byte>(expression,inclusive_validator,this,lower,upper);
        }

    }
}