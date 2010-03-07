namespace Validation.Mapping.ValidationBuilders.Dates.Years
{
    public interface IYearPartValidationBuilder<T> where T : class
    {
        BetweenValidationBuilder<T,CompositeValidationBuilder<T,IDateTimeEntryValidationBuilder<T>>,int> between(int lower, int upper);
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> less_than(int year);
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> greater_than(int year);
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> equal_to(int year);
    }
}