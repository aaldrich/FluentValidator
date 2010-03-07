using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validation.Mapping.ValidationBuilders.Dates;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class BetweenValidationBuilder<T, TReturnBuilder, TProperty> : ValidationBuilder<T>
        where TReturnBuilder : IValidationBuilder<T>
        where TProperty : IComparable 
        where T : class
    {
        readonly Expression<Func<T, TProperty>> expression;
        readonly InclusiveBetweenValidator<T, TProperty> inclusive_validator;
        readonly TReturnBuilder current_builder;
        readonly TProperty lower;
        readonly TProperty upper;

        public BetweenValidationBuilder(
            Expression<Func<T,TProperty>> expression,
            InclusiveBetweenValidator<T,TProperty> inclusive_validator
            ,TReturnBuilder current_builder
            ,TProperty lower,
            TProperty upper): base(current_builder.validators)
        {
            this.expression = expression;
            this.inclusive_validator = inclusive_validator;
            this.current_builder = current_builder;
            this.lower = lower;
            this.upper = upper;
        }

        /// <summary>
        /// Adds an Exclusive Between Validator. Exclusive will only check between
        /// greater than and less than it will not include equals.
        /// Removes the inclusive operator from the validators list.
        /// </summary>
        /// <returns>Composite Builder with the exclusive between added to the validators</returns>
        public CompositeValidationBuilder<T,TReturnBuilder> exclusive()
        {
            var exclusive_between_validator = 
                new ExclusiveBetweenValidator<T, TProperty>(expression,lower,upper);

            validators.Remove(inclusive_validator);
            validators.Add(exclusive_between_validator);

            var composite_builder = new CompositeValidationBuilder<T, TReturnBuilder>(current_builder);
            return composite_builder;
        }

        public TReturnBuilder and()
        {
            return current_builder;
        }
    }
}