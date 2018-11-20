using System;
using Castle.MicroKernel.Resolvers;
using Castle.Windsor;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces;
using SoberSoftware.CastleWindsor.Installation;
using SoberSoftware.CastleWindsor.Installation.Logging;

namespace SB_AppRunner
{
    internal class Program
    {
        public static string Implementation { get; set; }

        private static void Main(string[] args)
        {
            WindsorContainerWrapper installerWrapper =
                new WindsorContainerWrapper(new WindsorContainer(), new Registration(), new BackendServices());
            installerWrapper.RegistrationLogger = new ConsoleLogger();
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

            Console.ReadKey();
        }
    }
}