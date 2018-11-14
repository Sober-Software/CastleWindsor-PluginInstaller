using MT_AppRunner.Customer;

namespace MT_AppRunner.Output
{
    public interface IConsoleWriter
    {
        void WriteCustomerInformation(ICustomerInformation information);
    }
}