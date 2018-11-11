using System;
using AppRunner.Customer;

namespace Customer.Yoplait
{
    public class SomethingCompletelyDifferent : ICustomerInformation
    {
        public DateTime CustomerJoinDate => new DateTime(1990, 12, 6);

        public string CustomerName => "Yoplait";

        public string Location => "Israel";
    }
}