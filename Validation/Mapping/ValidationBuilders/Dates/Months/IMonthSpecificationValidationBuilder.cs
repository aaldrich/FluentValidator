namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public interface IMonthSpecificationValidationBuilder<T>
    {
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> January();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> February();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> March();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> April();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> May();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> June();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> July();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> August();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> September();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> October();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> November();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> December();
    }
}