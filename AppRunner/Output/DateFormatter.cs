namespace AppRunner.Output
{
    public class DateFormatter : IFormatter
    {
        public string GetFormat()
        {
            return "MMM dd, yyyy";
        }
    }
}