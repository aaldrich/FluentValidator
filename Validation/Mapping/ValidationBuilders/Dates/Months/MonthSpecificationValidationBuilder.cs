namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public partial class MonthValidationBuilder<T> 
    {
        CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> build_month(Month month)
        {
            return (CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>>)month_building_context.Invoke(month);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> January()
        {
            return build_month(Month.January); 
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> February()
        {
            return build_month(Month.February);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> March()
        {
            return build_month(Month.March);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> April()
        {
            return build_month(Month.April);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> May()
        {
            return build_month(Month.May);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> June()
        {
            return build_month(Month.June);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> July()
        {
            return build_month(Month.July);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> August()
        {
            return build_month(Month.August);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> September()
        {
            return build_month(Month.September);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> October()
        {
            return build_month(Month.October);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> November()
        {
            return build_month(Month.November);
        }

        public CompositeValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> December()
        {
            return build_month(Month.December);
        }
    }
}