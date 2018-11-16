using System;
using Castle.Windsor;
using MT_AppRunner.Customer;
using MT_AppRunner.Installation;
using MT_AppRunner.Output;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Licensing;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace MT_AppRunner
{
    public class Program
    {
        private static void Main(string[] args)
        {
            WindsorContainer container = new WindsorContainer();

            do
            {
                Console.Write("Customer Key: ");
                ContextUtilities.ContextValidationString = Console.ReadLine();
                ICustomerInformation customerInformation = container.Resolve<ICustomerInformation>();
                IConsoleWriter consoleWriter = container.Resolve<IConsoleWriter>();

                consoleWriter.WriteCustomerInformation(customerInformation);
            } while (Console.ReadLine() != "exit".ToLower());
        }
    }
}