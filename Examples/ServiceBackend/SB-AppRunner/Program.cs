using System;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SB_AppRunner
{
    internal class Program
    {
        public static string Implementation { get; set; }

        private static void Main(string[] args)
        {
            Registrator.InstallMainApplication(new Registration());
            Registrator.InstallPluginAssemblies(new BackendServices());

            IServiceProvider<string, BusinessResponse> serviceProvider =
                Registrator.Resolve<IServiceProvider<string, BusinessResponse>>();
            string serviceData = @"{ ""datafield"" : ""Some data""}";
            BusinessResponse response = serviceProvider.PerformService(serviceData);
            Console.WriteLine($"{response.Success}");

            foreach (string responseMessage in response.Messages)
            {
                Console.WriteLine($"{responseMessage}");
            }

            Console.Write("Implementation: ");
            Implementation = Console.ReadLine();

            serviceProvider = Registrator.Resolve<IServiceProvider<string, BusinessResponse>>();
            response = serviceProvider.PerformService(serviceData);
            Console.WriteLine($"{response.Success}");

            foreach (string responseMessage in response.Messages)
            {
                Console.WriteLine($"{responseMessage}");
            }
        }
    }
}