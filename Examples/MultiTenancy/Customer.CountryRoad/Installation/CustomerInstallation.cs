﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Customer.CountryRoad.Customer;
using MT_AppRunner.Customer;
using MT_AppRunner.Output;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace Customer.CountryRoad.Installation
{
    public class CustomerInstallation : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterThisAssembly(container);
            AddSelectionHandlers(container);
        }

        protected void AddSelectionHandlers(IWindsorContainer container)
        {
            AddHandlerSelector<CustomerInformation, ICustomerInformation>(container);
            AddHandlerSelector<DateTimeFormat, IFormatter>(container);
        }

        private void AddHandlerSelector<TImplementation, TService>(IWindsorContainer container,
            params ISelectionCriterion[] selectionCriteria)
            where TImplementation : class, TService where TService : class
        {
            container.AddImplementationCriteria<TImplementation, TService>(
                selectionCriteria);
        }

        private void RegisterThisAssembly(IWindsorContainer container)
        {
            container.RegisterThisAssembly();
        }
    }
}