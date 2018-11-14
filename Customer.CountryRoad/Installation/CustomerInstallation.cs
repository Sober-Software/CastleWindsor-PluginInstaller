using Castle.MicroKernel.Registration;
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
        protected string CustomerKey { get; }

        public CustomerInstallation()
        {
            CustomerKey = GetApiLicenseKey();
        }

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
            where TImplementation : TService where TService : class
        {
            Registrator.AddHandlerSelector<TImplementation, TService>(container,
                selectionCriteria);
        }

        private string GetApiLicenseKey()
        {
            return Registrator.GetCustomerApiKey();
        }

        private void RegisterThisAssembly(IWindsorContainer container)
        {
            Registrator.RegisterThisAssembly(container);
        }
    }
}