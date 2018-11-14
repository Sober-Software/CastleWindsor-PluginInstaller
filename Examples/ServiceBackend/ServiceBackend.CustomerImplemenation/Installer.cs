using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceBackend.CustomerImplemenation.ServiceLogic;
using ServiceBackend.Implementation.BusinessLogic;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace ServiceBackend.CustomerImplemenation
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IsImplementation2 isImplementation2 = new IsImplementation2(Registrator.Resolve<IContextProvider>());

            Registrator.RegisterThisAssembly(container);

            Registrator
                .AddHandlerSelector<CustomerBackendRequestTranslator,
                    IBackendRequestTranslator<ServiceRequest, BackendServiceRequest>>(container, isImplementation2);
            Registrator
                .AddHandlerSelector<CustomerBackendRequestSender,
                    IBackendRequestSender<BackendServiceRequest, BackendServiceResponse>>(container, isImplementation2);
        }
    }
}