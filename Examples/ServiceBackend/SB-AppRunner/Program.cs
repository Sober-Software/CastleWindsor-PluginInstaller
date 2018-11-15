using System;
using Castle.Windsor;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces;
using SoberSoftware.CastleWindsor.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SB_AppRunner
{
    internal class Program
    {
        public static string Implementation { get; set; }

        private static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainerWrapper(new WindsorContainer());
            container.InstallMainApplication(new Registration());
            container.InstallPluginAssemblies(new BackendServices());

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