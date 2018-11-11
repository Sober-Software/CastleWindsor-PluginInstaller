using System;
using AppRunner.Customer;

namespace Customer.CountryRoad.Customer
{
    public class CustomerInformation : ICustomerInformation
    {
        public DateTime CustomerJoinDate => DateTime.Now;

        public string CustomerName => "Country Road";

        public string Location => "West Virginia";
    }
}