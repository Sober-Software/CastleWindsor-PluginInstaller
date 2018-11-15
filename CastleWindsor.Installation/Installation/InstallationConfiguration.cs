using System;
using System.Collections.Generic;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public static class InstallationConfiguration
    {
        private static IMainAssemblyProvider mainAssemblyProvider;

        private static IPluginAssemblyProvider pluginAssemblyProvider;

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

        public static IPluginAssemblyProvider PluginAssemblyProvider
        {
            get
            {
                if (pluginAssemblyProvider == null)
                {
                    pluginAssemblyProvider = new DefaultPluginAssemblyProvider();
                }

                return pluginAssemblyProvider;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CustomerAssemblyProvider cannot be null.");
                }

                pluginAssemblyProvider = value;
            }
        }

        public static string GetApplicationEntryPoint()
        {
            return MainAssemblyProvider.GetAssemblyName();
        }

        public static IEnumerable<string> GetPluginAssemblyNames()
        {
            return PluginAssemblyProvider.GetAssemblyNames();
        }
    }
}