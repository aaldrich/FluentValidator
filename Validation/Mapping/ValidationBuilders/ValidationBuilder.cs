using System;
using System.Collections.Generic;
using Validation.Helpers;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders
{
    public class ValidationBuilder<T> : IValidationBuilder<T>, IObjectHidingHelper
    {
        public IList<IValidator<T>> validators { get; set; }
        public HashSet<IgnoreValidator> ignore_validators { get; set; }

        public ValidationBuilder(IList<IValidator<T>> validators, HashSet<IgnoreValidator> ignore_validators)
        {
            this.validators = validators;
            this.ignore_validators = ignore_validators;
        }
    }

    /// <summary>
    /// Placeholder interface to use for creating progressive interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidationBuilder<T>
    {
        IList<IValidator<T>> validators {get;set;}
        HashSet<IgnoreValidator> ignore_validators { get; set; }
    }
}