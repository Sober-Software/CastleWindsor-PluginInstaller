using System;
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