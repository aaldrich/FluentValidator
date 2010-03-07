using Validation.Mapping.ValidationBuilders.Dates.Days;
using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Mapping.ValidationBuilders.Dates.Years;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public interface IDateTimeEntryValidationBuilder<T> : IValidationBuilder<T> where T : class
    {
        IMonthEntryValidationBuilder<T> month();
        IYearEntryValidationBuilder<T> year();
        IDateEntryValidationBuilder<T> date();
        IDayEntryValidationBuilder<T> day();
    }
}