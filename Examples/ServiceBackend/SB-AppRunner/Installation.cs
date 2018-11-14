using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SB_AppRunner
{
    public class Installation : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Registrator.RegisterThisAssembly(container);
        }
    }
}