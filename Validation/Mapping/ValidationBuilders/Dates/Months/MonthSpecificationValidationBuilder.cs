namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public partial class MonthValidationBuilder<T,TCurrentBuilder> 
    {
        CompositeValidationBuilder<T, TCurrentBuilder> build_month(Month month)
        {
            return (CompositeValidationBuilder<T, TCurrentBuilder>)month_building_context.Invoke(month);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> January()
        {
            return build_month(Month.January); 
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> February()
        {
            return build_month(Month.February);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> March()
        {
            return build_month(Month.March);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> April()
        {
            return build_month(Month.April);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> May()
        {
            return build_month(Month.May);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> June()
        {
            return build_month(Month.June);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> July()
        {
            return build_month(Month.July);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> August()
        {
            return build_month(Month.August);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> September()
        {
            return build_month(Month.September);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> October()
        {
            return build_month(Month.October);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> November()
        {
            return build_month(Month.November);
        }

        public CompositeValidationBuilder<T, TCurrentBuilder> December()
        {
            return build_month(Month.December);
        }
    }
}