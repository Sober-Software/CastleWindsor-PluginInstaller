﻿using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceBackend.CustomerImplemenation.ServiceLogic;
using ServiceBackend.Implementation.BusinessLogic;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace ServiceBackend.CustomerImplemenation
{
    public class Installer : IScenarioInstaller
    {
        public void DeclareDefaultServiceImplementations(IWindsorContainer container, IConfigurationStore store)
        {
            // None.
        }

        public void DeclareResolutionScenarios(IWindsorContainer container, IConfigurationStore store)
        {
            IsImplementation2 isImplementation2 = new IsImplementation2(container.Resolve<IContextProvider<string>>());

            container
                .AddImplementationCriteria<CustomerBackendRequestTranslator,
                    IBackendRequestTranslator<ServiceRequest, BackendServiceRequest>>(isImplementation2);
            container
                .AddImplementationCriteria<CustomerBackendRequestSender,
                    IBackendRequestSender<BackendServiceRequest, BackendServiceResponse>>(isImplementation2);

            container
                .AddImplementationCriteria<CustomerBackendSender,
                    IBackendRequestSender<BackendServiceRequest, BackendServiceResponse>>();
        }

        public void InstallAssembly(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterThisAssembly();
        }
    }
}