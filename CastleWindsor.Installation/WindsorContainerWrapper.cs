using System;
using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Logging;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SoberSoftware.CastleWindsor.Installation
{
    public class WindsorContainerWrapper
    {
        private IRegistrationLogger registrationLogger;

        private IWindsorContainer windsorContainer;

        public IInstallationStrategy InstallationStrategy { get; }

        public IMainAssemblyProvider MainAssemblyProvider { get; }

        public IPluginAssembliesProvider PluginAssembliesProvider { get; }

        public IRegistrationLogger RegistrationLogger
        {
            get
            {
                if (registrationLogger == null)
                {
                    registrationLogger = new NullLogger();
                }

                return registrationLogger;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(RegistrationLogger)} cannot be null.");
                }

                registrationLogger = value;
            }
        }

        public IWindsorContainer WindsorContainer
        {
            get => windsorContainer;
            private set
            {
                windsorContainer = value;
                windsorContainer.Kernel.ComponentRegistered += LogComponentRegistered;
                windsorContainer.Kernel.ComponentCreated += LogComponentCreated;
            }
        }

        private void LogComponentCreated(ComponentModel model, object instance)
        {
            RegistrationLogger.LogComponentCreated(model, instance);
        }

        private void LogComponentRegistered(string key, IHandler handler)
        {
            RegistrationLogger.LogRegistration(key, handler);
        }

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