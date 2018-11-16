using System;
using Castle.Windsor;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SoberSoftware.CastleWindsor.Installation
{
    public class WindsorContainerWrapper
    {
        public IInstallationStrategy InstallationStrategy { get; }

        public IMainAssemblyProvider MainAssemblyProvider { get; }

        public IPluginAssembliesProvider PluginAssembliesProvider { get; }

        public IWindsorContainer WindsorContainer { get; }

        public WindsorContainerWrapper(IWindsorContainer container, IMainAssemblyProvider mainAssemblyProvider,
            IPluginAssembliesProvider pluginAssembliesProvider)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (mainAssemblyProvider == null)
            {
                throw new ArgumentNullException(nameof(mainAssemblyProvider));
            }

            if (pluginAssembliesProvider == null)
            {
                throw new ArgumentNullException(nameof(pluginAssembliesProvider));
            }

            WindsorContainer = container;
            MainAssemblyProvider = mainAssemblyProvider;
            PluginAssembliesProvider = pluginAssembliesProvider;
            InstallationStrategy = new DefaultInstallationStrategy(mainAssemblyProvider, pluginAssembliesProvider);
        }

        public WindsorContainerWrapper(IWindsorContainer container, IMainAssemblyProvider mainAssemblyProvider) : this(
            container, mainAssemblyProvider, new DefaultPluginAssembliesProvider())
        {
        }

        public WindsorContainerWrapper(IWindsorContainer container, IInstallationStrategy installationStrategy)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (installationStrategy == null)
            {
                throw new ArgumentNullException(nameof(installationStrategy));
            }

            WindsorContainer = container;
            InstallationStrategy = installationStrategy;
            MainAssemblyProvider = installationStrategy.MainAssemblyProvider;
            PluginAssembliesProvider = installationStrategy.PluginAssembliesProvider;
        }

        public void Install()
        {
            InstallationStrategy.InstallMainApplication(WindsorContainer);
            InstallationStrategy.InstallPluginAssemblies(WindsorContainer);
        }
    }
}