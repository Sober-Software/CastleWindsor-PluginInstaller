﻿using System;
using MT_AppRunner.Customer;

namespace MT_AppRunner.Output
{
    public class DefaultConsoleWriter : IConsoleWriter
    {
        private readonly IFormatter formatter;

        public DefaultConsoleWriter(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public void WriteCustomerInformation(ICustomerInformation information)
        {
            Console.WriteLine(information.CustomerName);
            Console.WriteLine(information.Location);
            Console.WriteLine(information.CustomerJoinDate.ToString(formatter.GetFormat()));
        }
    }
}