using ServiceBackend.CustomerImplemenation.ServiceLogic;
using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace ServiceBackend.CustomerImplemenation
{
    public class IsImplementation3 : ISelectionCriterion<CustomerBackendSender>
    {
        private readonly IContextProvider<string> contextProvider;

        public IsImplementation3(IContextProvider<string> contextProvider)
        {
            this.contextProvider = contextProvider;
        }

        public bool IsTrue()
        {
            return contextProvider.GetContext() == "3";
        }
    }
}