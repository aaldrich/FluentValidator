namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthSpecificationValidationBuilder<T,TCurrentBuilder>
        where TCurrentBuilder : ValidationBuilder<T>
    {
        CompositeValidationBuilder<T, TCurrentBuilder> January();
        CompositeValidationBuilder<T, TCurrentBuilder> February();
        CompositeValidationBuilder<T, TCurrentBuilder> March();
        CompositeValidationBuilder<T, TCurrentBuilder> April();
        CompositeValidationBuilder<T, TCurrentBuilder> May();
        CompositeValidationBuilder<T, TCurrentBuilder> June();
        CompositeValidationBuilder<T, TCurrentBuilder> July();
        CompositeValidationBuilder<T, TCurrentBuilder> August();
        CompositeValidationBuilder<T, TCurrentBuilder> September();
        CompositeValidationBuilder<T, TCurrentBuilder> October();
        CompositeValidationBuilder<T, TCurrentBuilder> November();
        CompositeValidationBuilder<T, TCurrentBuilder> December();
    }
}