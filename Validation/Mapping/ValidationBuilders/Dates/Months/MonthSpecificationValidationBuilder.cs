namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public partial class MonthValidationBuilder<T,TCurrentBuilder> 
    {
        CompositeValidationBuilder<T, TCurrentBuilder> build_month(Dates.Months.Month month)
        {
            return (CompositeValidationBuilder<T, TCurrentBuilder>)month_building_context.Invoke(month);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> January()
        {
            return build_month(Dates.Months.Month.January); 
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> February()
        {
            return build_month(Dates.Months.Month.February);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> March()
        {
            return build_month(Dates.Months.Month.March);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> April()
        {
            return build_month(Dates.Months.Month.April);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> May()
        {
            return build_month(Dates.Months.Month.May);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> June()
        {
            return build_month(Dates.Months.Month.June);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> July()
        {
            return build_month(Dates.Months.Month.July);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> August()
        {
            return build_month(Dates.Months.Month.August);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> September()
        {
            return build_month(Dates.Months.Month.September);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> October()
        {
            return build_month(Dates.Months.Month.October);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> November()
        {
            return build_month(Dates.Months.Month.November);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> December()
        {
            return build_month(Dates.Months.Month.December);
        }
    }
}