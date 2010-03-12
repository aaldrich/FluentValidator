using Validation.Mapping.ValidationBuilders.Failure;

namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public partial class MonthValidationBuilder<T> where T : class
    {
        IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> build_month(Month month)
        {
            return month_building_context.Invoke(month);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> January()
        {
            return build_month(Month.January); 
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> February()
        {
            return build_month(Month.February);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> March()
        {
            return build_month(Month.March);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> April()
        {
            return build_month(Month.April);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> May()
        {
            return build_month(Month.May);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> June()
        {
            return build_month(Month.June);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> July()
        {
            return build_month(Month.July);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> August()
        {
            return build_month(Month.August);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> September()
        {
            return build_month(Month.September);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> October()
        {
            return build_month(Month.October);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> November()
        {
            return build_month(Month.November);
        }

        public IFailureEntryValidationBuilder<T, IDateTimeEntryValidationBuilder<T>> December()
        {
            return build_month(Month.December);
        }
    }
}