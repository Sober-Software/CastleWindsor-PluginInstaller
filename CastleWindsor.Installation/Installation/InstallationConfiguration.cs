using System;
using System.Collections.Generic;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public static class InstallationConfiguration
    {
        private static IMainAssemblyProvider mainAssemblyProvider;

        private static IPluginAssembliesProvider pluginAssembliesProvider;

        public static IMainAssemblyProvider MainAssemblyProvider
        {
            get
            {
                if (mainAssemblyProvider == null)
                {
                    throw new InvalidOperationException("MainAssemblyProvider has not been set.");
                }

                return mainAssemblyProvider;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("MainAssemblyProvider cannot be null");
                }

                mainAssemblyProvider = value;
            }
        }

        public static IPluginAssembliesProvider PluginAssembliesProvider
        {
            get
            {
                if (pluginAssembliesProvider == null)
                {
                    pluginAssembliesProvider = new DefaultPluginAssembliesProvider();
                }

                return pluginAssembliesProvider;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CustomerAssemblyProvider cannot be null.");
                }

                pluginAssembliesProvider = value;
            }
        }
    }
}