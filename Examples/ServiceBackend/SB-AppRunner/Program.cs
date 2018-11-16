using System;
using Castle.Windsor;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces;
using SoberSoftware.CastleWindsor.Installation;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SB_AppRunner
{
    internal class Program
    {
        public static string Implementation { get; set; }

        private static void Main(string[] args)
        {
            IInstallationStrategy strategy = new DefaultInstallationStrategy(new Registration());
            strategy.PluginAssembliesProvider = new DefaultPluginAssembliesProvider();

            WindsorContainerWrapper installerWrapper = new WindsorContainerWrapper(new WindsorContainer(), new Registration(), new BackendServices());
            installerWrapper.Install();
            IWindsorContainer container = installerWrapper.WindsorContainer;

            IServiceProvider<string, BusinessResponse> serviceProvider =
                container.Resolve<IServiceProvider<string, BusinessResponse>>();
            string serviceData = @"{ ""datafield"" : ""Some data""}";
            BusinessResponse response = serviceProvider.PerformService(serviceData);
            Console.WriteLine($"{response.Success}");

            foreach (string responseMessage in response.Messages)
            {
                Console.WriteLine($"{responseMessage}");
            }

            Console.Write("Implementation: ");
            Implementation = Console.ReadLine();

            serviceProvider = container.Resolve<IServiceProvider<string, BusinessResponse>>();
            response = serviceProvider.PerformService(serviceData);
            Console.WriteLine($"{response.Success}");

            foreach (string responseMessage in response.Messages)
            {
                Console.WriteLine($"{responseMessage}");
            }
        }
    }
}