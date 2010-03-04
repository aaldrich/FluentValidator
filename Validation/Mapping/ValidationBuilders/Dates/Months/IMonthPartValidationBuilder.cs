namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthPartValidationBuilder<T, TCurrentBuilder>
        where TCurrentBuilder : ValidationBuilder<T>
    {
        BetweenValidationBuilder<T, MonthValidationBuilder<T,TCurrentBuilder>,int> between(Month lower, Month upper);
        IMonthSpecificationValidationBuilder<T, TCurrentBuilder> less_than();
        IMonthSpecificationValidationBuilder<T, TCurrentBuilder> greater_than();
        IMonthSpecificationValidationBuilder<T, TCurrentBuilder> equal_to();
    }
}