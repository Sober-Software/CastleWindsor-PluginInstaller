using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public static class ContainerRegistrationExtensions
    {
        public static void AddHandlerSelector<TImplementation, TService>(this IWindsorContainer container,
            params ISelectionCriterion[] selectionCriteria)
            where TImplementation : TService where TService : class
        {
            container.Kernel.AddHandlerSelector(
                new HandlerSelector<TImplementation, TService>(selectionCriteria));
        }

        public static void RegisterThisAssembly(this IWindsorContainer container)
        {
            container.Register(Classes.FromAssembly(Assembly.GetCallingAssembly()).Pick().WithServiceAllInterfaces()
                .LifestyleTransient());
        }

        public static void InstallMainApplication(this IWindsorContainer container, IMainAssemblyProvider mainAssemblyProvider)
        {
            container.Install(FromAssembly.Named(mainAssemblyProvider.GetAssemblyName()));
        }

        public static void InstallPluginAssemblies(this IWindsorContainer container, IPluginAssemblyProvider pluginAssemblyProvider)
        {
            IEnumerable<string> pluginAssemblyNames = pluginAssemblyProvider.GetAssemblyNames();

            foreach (string assemblyName in pluginAssemblyNames)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"{assemblyName}.dll");
                Assembly assembly = Assembly.LoadFrom(path);
                container.Install(FromAssembly.Instance(assembly));
            }
        }
    }
}