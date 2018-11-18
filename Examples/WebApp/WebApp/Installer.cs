using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceBackend.Interfaces;
using SoberSoftware.CastleWindsor.Installation.Registration;
using WebApp.Implementation;

namespace WebApp
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterThisAssembly();
            container.Register(Classes.FromAssemblyNamed("ServiceBackend.Interfaces").Pick().WithServiceAllInterfaces()
                .LifestyleTransient());

            container.AddHandlerSelector<ServiceProvider, IServiceProvider<string, int>>(new AlwaysTrue());
            container.AddHandlerSelector<SecondService, IServiceProvider<string, int>>(new AlwaysFalse());
        }
    }
}