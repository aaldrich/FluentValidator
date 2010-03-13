namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthPartValidationBuilder<T> where T : class
    {
        BetweenValidationBuilder<T,IDateTimeEntryValidationBuilder<T>,int> between(Month lower, Month upper);
        IMonthSpecificationValidationBuilder<T> less_than();
        IMonthSpecificationValidationBuilder<T> less_than_or_equal_to();
        IMonthSpecificationValidationBuilder<T> greater_than();
        IMonthSpecificationValidationBuilder<T> greater_than_or_equal_to();
        IMonthSpecificationValidationBuilder<T> equal_to();
    }
}