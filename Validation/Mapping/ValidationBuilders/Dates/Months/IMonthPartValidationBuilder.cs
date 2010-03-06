namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthPartValidationBuilder<T>
    {
        BetweenValidationBuilder<T,CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>>,int> between(Month lower, Month upper);
        IMonthSpecificationValidationBuilder<T> less_than();
        IMonthSpecificationValidationBuilder<T> greater_than();
        IMonthSpecificationValidationBuilder<T> equal_to();
    }
}