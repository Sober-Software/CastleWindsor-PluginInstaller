using MT_AppRunner.Output;

namespace Customer.CountryRoad
{
    public class DateTimeFormat : IFormatter
    {
        public string GetFormat()
        {
            return "MM-dd-yyyy hh:mm:ss";
        }
    }
}