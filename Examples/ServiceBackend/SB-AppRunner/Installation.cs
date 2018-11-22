using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SB_AppRunner.Logging;
using ServiceBackend.Interfaces.Logging;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;
using SoberSoftware.CastleWindsor.Installation.SelectionCriteria;

namespace SB_AppRunner
{
    public class Installation : IScenarioInstaller
    {
        public void DeclareDefaultServiceImplementations(IWindsorContainer container, IConfigurationStore store)
        {
            container.DeclareServiceDefault<ConsoleLogger, ILogger>();
        }

        public void DeclareResolutionScenarios(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddImplementationCriteria<ConsoleLogger, ILogger>(new AlwaysFalse());
            container.AddImplementationCriteria<NullLogger, ILogger>(new AlwaysFalse());
        }

        public void InstallAssembly(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterThisAssembly();
        }
    }
}