using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Validation.Helpers;
using Validation.Mapping.ValidationBuilders;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationMappers
{
    public partial class ValidationMap<T> : IValidationMap
    {
        public IList<IValidator<T>> validators {get; protected set;}

        public ValidationMap()
        {
            validators = new List<IValidator<T>>();
        }

        //I want to build a generic builder entry point but I'm having trouble
        //building a new expression. Will do it later.
        //public TBuilder Map<TBuilder,TProperty>(Expression<Func<T, TProperty>> expression)
        //    where TBuilder : ValidationBuilder<T>
        //    where TProperty : Type
        //{
            
        //    if (typeof(TProperty).Equals(typeof(long)))
        //    {
        //        Expression<Func<T,long>> new_expression 
        //            = Expression.Lambda<Func<T,long>>(expression.Body,expression.Parameters);

        //        return new LongValidationBuilder<T>(new_expression, validators);
        //    }
        //}
        public Type ValidationType
        {
            get { return typeof(T); }
        }
    }

    public interface IValidationMap : IObjectHidingHelper
    {
        Type ValidationType { get; }
    }
}