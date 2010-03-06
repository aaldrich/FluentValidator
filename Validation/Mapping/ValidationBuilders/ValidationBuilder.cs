using System;
using System.Collections.Generic;
using Validation.Helpers;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class ValidationBuilder<T> : IValidationBuilder<T>, IObjectHidingHelper
    {
        private IList<IValidator<T>> _validators;

        public ValidationBuilder(IList<IValidator<T>> validators)
        {
            this.validators = validators;
        }

        public IList<IValidator<T>> validators 
        {
            get { return _validators; }
            set { _validators = value; }
        }
    }

    /// <summary>
    /// Placeholder interface to use for creating progressive interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidationBuilder<T>
    {
        IList<IValidator<T>> validators {get;set;}
    }
}