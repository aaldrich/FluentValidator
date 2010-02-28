namespace Validation.Mapping.ValidationBuilders
{
    /// <summary>
    /// Lets you build a progressive interface where the interface changes 
    /// depending on the current context path. and is the gateway to the 
    /// next ValidationBuilder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCurrentBuilder"></typeparam>
    public class CompositeValidationBuilder<T,TCurrentBuilder>
        : ValidationBuilder<T> where TCurrentBuilder : ValidationBuilder<T>
    {
        readonly TCurrentBuilder current_builder;

        public CompositeValidationBuilder(TCurrentBuilder current_builder)
            : base(current_builder.validators)
        {
            this.current_builder = current_builder;
        }

        public TCurrentBuilder and()
        {
            return current_builder; 
        }
    }
}