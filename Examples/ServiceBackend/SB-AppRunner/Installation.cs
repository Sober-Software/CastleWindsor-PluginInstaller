using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SB_AppRunner.Logging;
using ServiceBackend.Interfaces.Logging;
using SoberSoftware.CastleWindsor.Installation.Registration;
using SoberSoftware.CastleWindsor.Installation.SelectionCriteria;

namespace SB_AppRunner
{
    public class Installation : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterThisAssembly();
            
            container.AddHandlerSelector<NullLogger, ILogger>(new AlwaysFalse());
            container.AddHandlerSelector<ConsoleLogger, ILogger>(new AlwaysFalse());
        }
    }
}