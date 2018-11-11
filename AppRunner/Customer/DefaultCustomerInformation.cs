using System;

namespace AppRunner.Customer
{
    public class DefaultCustomerInformation : ICustomerInformation
    {
        public DateTime CustomerJoinDate => new DateTime(1982, 1, 1);

        public string CustomerName => "ICS";

        public string Location => "Jacksonville, FL";
    }
}