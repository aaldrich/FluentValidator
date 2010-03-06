using Validation.Mapping.ValidationBuilders.Dates.Months;
using Validation.Mapping.ValidationBuilders.Dates.Years;

namespace Validation.Mapping.ValidationBuilders.Dates
{
    public interface IDateTimeEntryValidationBuilder<T> : IValidationBuilder<T>
    {
        IMonthEntryValidationBuilder<T> month();
        IYearEntryValidationBuilder<T> year();
        IDateEntryValidationBuilder<T> date();
    }
}