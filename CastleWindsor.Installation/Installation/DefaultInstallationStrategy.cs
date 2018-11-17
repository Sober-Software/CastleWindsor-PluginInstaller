using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    internal class DefaultInstallationStrategy : IInstallationStrategy
    {
        public IMainAssemblyProvider MainAssemblyProvider { get; }

        public IPluginAssembliesProvider PluginAssembliesProvider { get; }

        public DefaultInstallationStrategy(IMainAssemblyProvider mainAssemblyProvider) : this(mainAssemblyProvider,
            new DefaultPluginAssembliesProvider())
        {
        }

        public DefaultInstallationStrategy(IMainAssemblyProvider mainAssemblyProvider,
            IPluginAssembliesProvider pluginAssembliesProvider)
        {
            if (mainAssemblyProvider == null)
            {
                throw new ArgumentNullException(nameof(mainAssemblyProvider));
            }

            if (pluginAssembliesProvider == null)
            {
                throw new ArgumentNullException(nameof(pluginAssembliesProvider));
            }

            MainAssemblyProvider = mainAssemblyProvider;
            PluginAssembliesProvider = pluginAssembliesProvider;
        }

        public void InstallMainApplication(IWindsorContainer container)
        {
            container.Install(FromAssembly.Instance(MainAssemblyProvider.GetAssembly()));
        }

        public void InstallPluginAssemblies(IWindsorContainer container)
        {
            IEnumerable<Assembly> pluginAssemblies = PluginAssembliesProvider.GetAssemblies();

            foreach (Assembly assembly in pluginAssemblies)
            {
                container.Install(FromAssembly.Instance(assembly));
            }
        }
    }
}