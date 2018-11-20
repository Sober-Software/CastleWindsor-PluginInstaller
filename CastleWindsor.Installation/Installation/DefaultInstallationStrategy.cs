using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    internal class DefaultInstallationStrategy : IInstallationStrategy
    {
        public InstallerFactory InstallerFactory { get; }

        public IMainAssemblyProvider MainAssemblyProvider { get; }

        public IPluginAssembliesProvider PluginAssembliesProvider { get; }

        public DefaultInstallationStrategy(IMainAssemblyProvider mainAssemblyProvider) : this(mainAssemblyProvider,
            new DefaultPluginAssembliesProvider(), new InstallerPriority())
        {
        }

        public DefaultInstallationStrategy(IMainAssemblyProvider mainAssemblyProvider,
            IPluginAssembliesProvider pluginAssembliesProvider) : this(mainAssemblyProvider, pluginAssembliesProvider,
            new InstallerFactory())
        {
        }

        public DefaultInstallationStrategy(IMainAssemblyProvider mainAssemblyProvider,
            IPluginAssembliesProvider pluginAssembliesProvider, InstallerFactory installerFactory)
        {
            if (mainAssemblyProvider == null)
            {
                throw new ArgumentNullException(nameof(mainAssemblyProvider));
            }

            if (pluginAssembliesProvider == null)
            {
                throw new ArgumentNullException(nameof(pluginAssembliesProvider));
            }

            if (installerFactory == null)
            {
                throw new ArgumentNullException(nameof(installerFactory));
            }

            MainAssemblyProvider = mainAssemblyProvider;
            PluginAssembliesProvider = pluginAssembliesProvider;
            InstallerFactory = installerFactory;
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
                container.Install(FromAssembly.Instance(assembly, InstallerFactory));
            }
        }
    }
}