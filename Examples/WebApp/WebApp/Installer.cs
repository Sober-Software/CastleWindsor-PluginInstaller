using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceBackend.Interfaces;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;
using SoberSoftware.CastleWindsor.Installation.SelectionCriteria;
using WebApp.Implementation;

namespace WebApp
{
    public class Installer : IScenarioInstaller
    {
        public void DeclareDefaultServiceImplementations(IWindsorContainer container, IConfigurationStore store)
        {
            // None
        }

        public void DeclareResolutionScenarios(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddImplementationCriteria<ServiceProvider, IServiceProvider<string, int>>(new AlwaysTrue());
            container.AddImplementationCriteria<SecondService, IServiceProvider<string, int>>(new AlwaysFalse());
        }

        public void InstallAssembly(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterThisAssembly();
            container.Register(Classes.FromAssemblyNamed("ServiceBackend.Interfaces").Pick().WithServiceAllInterfaces()
                .LifestyleTransient());
        }
    }
}