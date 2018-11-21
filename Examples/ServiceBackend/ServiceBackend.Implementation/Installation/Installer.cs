using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace ServiceBackend.Implementation.Installation
{
    public class Installer : IScenarioInstaller
    {
        public void DeclareDefaultServiceImplementations(IWindsorContainer container, IConfigurationStore store)
        {
            // None
        }

        public void DeclareResolutionScenarios(IWindsorContainer container, IConfigurationStore store)
        {
            // None
        }

        public void InstallAssembly(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterThisAssembly();
        }
    }
}