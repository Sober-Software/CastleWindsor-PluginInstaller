using System;

namespace MT_AppRunner.Customer
{
    public interface ICustomerInformation
    {
        DateTime CustomerJoinDate { get; }

        string CustomerName { get; }

        string Location { get; }
    }
}