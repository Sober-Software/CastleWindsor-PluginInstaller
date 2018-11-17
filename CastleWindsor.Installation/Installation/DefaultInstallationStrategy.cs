using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public class DefaultInstallationStrategy : IInstallationStrategy
    {
        private readonly IMainAssemblyProvider mainAssemblyProvider;

        private readonly IPluginAssembliesProvider pluginAssembliesProvider;

        public IMainAssemblyProvider MainAssemblyProvider
        {
            get => mainAssemblyProvider;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(mainAssemblyProvider)} cannot be null.");
                }
            }
        }

        public IPluginAssembliesProvider PluginAssembliesProvider
        {
            get => pluginAssembliesProvider;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(PluginAssembliesProvider)} cannot be null.");
                }
            }
        }

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

            this.mainAssemblyProvider = mainAssemblyProvider;
            this.pluginAssembliesProvider = pluginAssembliesProvider;
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