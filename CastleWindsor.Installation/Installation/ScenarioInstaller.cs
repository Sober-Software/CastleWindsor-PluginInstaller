using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public class ScenarioInstaller : IWindsorInstaller
    {
        private readonly Assembly assembly;

        private readonly InstallerFactory factory;

        public ScenarioInstaller(Assembly assembly, InstallerFactory factory)
        {
            this.assembly = assembly;
            this.factory = factory;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IEnumerable<Type> types = factory.Select(FilterInstallerTypes(assembly.GetAvailableTypes()));

            if (types == null)
            {
                return;
            }

            foreach (Type installerType in types)
            {
                IScenarioInstaller installer = installerType.CreateInstance<IScenarioInstaller>(Array.Empty<object>());
                RunInstaller(installer, container, store);
            }
        }

        private IEnumerable<Type> FilterInstallerTypes(IEnumerable<Type> types)
        {
            return types.Where(t =>
            {
                if (t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && !t.GetTypeInfo().IsGenericTypeDefinition)
                {
                    return t.Is<IScenarioInstaller>();
                }

                return false;
            });
        }

        private void RunInstaller(IScenarioInstaller installer, IWindsorContainer container, IConfigurationStore store)
        {
            installer.DeclareDefaultServiceImplementations(container, store);
            installer.InstallAssembly(container, store);
            installer.DeclareResolutionScenarios(container, store);
        }
    }
}