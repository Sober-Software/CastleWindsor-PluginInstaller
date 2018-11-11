using AppRunner.Customer;

namespace AppRunner.Output
{
    public interface IConsoleWriter
    {
        void WriteCustomerInformation(ICustomerInformation information);
    }
}