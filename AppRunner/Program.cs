using System;
using AppRunner.Customer;
using AppRunner.Installation;
using AppRunner.Output;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Licensing;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace AppRunner
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Registrator.InstallMainApplication(new MainAssemblyProvider());
            Registrator.InstallPluginAssemblies(Registrator.Resolve<IPluginAssemblyProvider>());

            do
            {
                Console.Write("Customer Key: ");
                ContextUtilities.ContextValidationString = Console.ReadLine();
                ICustomerInformation customerInformation = Registrator.Resolve<ICustomerInformation>();
                IConsoleWriter consoleWriter = Registrator.Resolve<IConsoleWriter>();

                consoleWriter.WriteCustomerInformation(customerInformation);
            } while (Console.ReadLine() != "exit".ToLower());
        }
    }
}