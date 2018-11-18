using System;
using Castle.Windsor;
using MT_AppRunner.Customer;
using MT_AppRunner.Installation;
using MT_AppRunner.Output;
using SoberSoftware.CastleWindsor.Installation;
using SoberSoftware.CastleWindsor.Installation.Logging;

namespace MT_AppRunner
{
    public class Program
    {
        private static void Main(string[] args)
        {
            WindsorContainerWrapper containerWrapper = new WindsorContainerWrapper(new WindsorContainer(),
                new MainAssemblyProvider(), new PluginRegistration());
            containerWrapper.RegistrationLogger = new ConsoleLogger();
            containerWrapper.Install();
            IWindsorContainer container = containerWrapper.WindsorContainer;

            do
            {
                Console.Write("Customer Key: ");
                Console.ReadLine();
                //ContextUtilities.ContextValidationString = Console.ReadLine();
                ICustomerInformation customerInformation = container.Resolve<ICustomerInformation>();
                IConsoleWriter consoleWriter = container.Resolve<IConsoleWriter>();

                consoleWriter.WriteCustomerInformation(customerInformation);
            } while (Console.ReadLine() != "exit".ToLower());
        }
    }
}