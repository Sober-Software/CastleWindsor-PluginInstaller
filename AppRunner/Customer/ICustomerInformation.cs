using System;

namespace AppRunner.Customer
{
    public interface ICustomerInformation
    {
        DateTime CustomerJoinDate { get; }

        string CustomerName { get; }

        string Location { get; }
    }
}