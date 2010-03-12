namespace Validation.Mapping.ValidationBuilders.Dates
{
    public partial class DateValidationBuilder<T> where T : class
    {
        public IDateSpecificationValidationBuilder<T> should_be()
        {
            return this;
        }

        public IDateSpecificationValidationBuilder<T> should_not_be()
        {
            base.should_wrap_with_not = true;
            return this;
        }
    }
}