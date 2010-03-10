namespace Validation.Mapping.ValidationBuilders
{
    /// <summary>
    /// Lets you build a progressive interface where the interface changes 
    /// depending on the current context path. and is the gateway to the 
    /// next ValidationBuilder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TReturnBuilder"></typeparam>
    public class CompositeValidationBuilder<T,TReturnBuilder>
        : ValidationBuilder<T> where TReturnBuilder : IValidationBuilder<T>
    {
        readonly IValidationBuilder<T> return_builder;

        public CompositeValidationBuilder(IValidationBuilder<T> return_builder)
            : base(return_builder.validators,return_builder.ignore_validators)
        {
            this.return_builder = return_builder;
        }

        public TReturnBuilder and()
        {
            return (TReturnBuilder)return_builder; 
        }
    }
}