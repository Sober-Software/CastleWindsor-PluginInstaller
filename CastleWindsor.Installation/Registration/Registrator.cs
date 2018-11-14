using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Licensing;

namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public static class Registrator
    {
        private static WindsorContainer containerInstance;

        private static WindsorContainer ContainerInstance
        {
            get
            {
                if (containerInstance == null)
                {
                    containerInstance = new WindsorContainer();
                    containerInstance.Kernel.ComponentRegistered += LogRegistration;
                    containerInstance.Kernel.ComponentCreated += LogComponentCreation;
                }

                return containerInstance;
            }
        }

        public static void AddHandlerSelector<TImplementation, TService>(IWindsorContainer container,
            params ISelectionCriterion[] selectionCriteria)
            where TImplementation : TService where TService : class
        {
            container.Kernel.AddHandlerSelector(
                new HandlerSelector<TImplementation, TService>(selectionCriteria));
        }
        
        public static void InstallMainApplication(IMainAssemblyProvider mainAssemblyProvider)
        {
            InstallationConfiguration.MainAssemblyProvider = mainAssemblyProvider;
            InstallMainApplication();
        }

        public static void InstallPluginAssemblies(IPluginAssemblyProvider pluginAssemblyProvider)
        {
            InstallationConfiguration.PluginAssemblyProvider = pluginAssemblyProvider;
            InstallPluginAssemblies();
        }

        public static void LogComponentCreation(ComponentModel model, object o)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Resolved ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{model.ComponentName}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" as ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{model.Services.First()}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogRegistration(string key, IHandler handler)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Registered {key} for {handler.ComponentModel.Services.First().Name}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void RegisterThisAssembly(IWindsorContainer container)
        {
            container.Register(Classes.FromAssembly(Assembly.GetCallingAssembly()).Pick().WithServiceAllInterfaces()
                .LifestyleTransient());
        }

        public static T Resolve<T>() where T : class
        {
            return ContainerInstance.Resolve<T>();
        }

        private static void InstallMainApplication()
        {
            ContainerInstance.Install(FromAssembly.Named(InstallationConfiguration.GetMainAssemblyName()));
        }

        private static void InstallPluginAssemblies()
        {
            IEnumerable<string> pluginAssemblyNames = InstallationConfiguration.GetPluginAssemblyNames();

            foreach (string assemblyName in pluginAssemblyNames)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"{assemblyName}.dll");
                Assembly assembly = Assembly.LoadFrom(path);
                ContainerInstance.Install(FromAssembly.Instance(assembly));
            }
        }
    }
}