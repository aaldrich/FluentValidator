namespace Validation.Mapping.ValidationBuilders.Dates.Months
{
    public class Month
    {
        public readonly int value;
        public readonly string name;

        protected Month(int value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public static Month January = new Month(1,"January");
        public static Month February = new Month(2,"February");
        public static Month March = new Month(3,"March");
        public static Month April = new Month(4, "April");
        public static Month May = new Month(5, "May");
        public static Month June = new Month(6, "June");
        public static Month July = new Month(7, "July");
        public static Month August = new Month(8, "August");
        public static Month September = new Month(9, "September");
        public static Month October = new Month(10, "October");
        public static Month November = new Month(11, "November");
        public static Month December = new Month(12, "December");
    }
}