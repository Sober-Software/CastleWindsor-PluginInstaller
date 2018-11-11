﻿using System;
using System.Collections.Generic;

namespace CastleWindsor.Installation.Installation
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

        public static IEnumerable<string> GetCustomerAssemblyNames()
        {
            return PluginAssemblyProvider.GetAssemblyNames();
        }

        public static string GetMainAssemblyName()
        {
            return MainAssemblyProvider.GetAssemblyName();
        }
    }
}