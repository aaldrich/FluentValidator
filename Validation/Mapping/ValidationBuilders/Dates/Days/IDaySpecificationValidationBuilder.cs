namespace Validation.Mapping.ValidationBuilders.Dates.Days
{
    public interface IDaySpecificationValidationBuilder<T>
    {
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Sunday();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Monday();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Tuesday();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Wednesday();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Thursday();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Friday();
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> Saturday();
    }
}