using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace ServiceBackend.CustomerImplemenation
{
    public class IsImplementation2 : ISelectionCriterion
    {
        private readonly IContextProvider<string> contextProvider;

        public IsImplementation2(IContextProvider<string> contextProvider)
        {
            this.contextProvider = contextProvider;
        }

        public bool IsTrue()
        {
            return contextProvider.GetContext() == "2";
        }
    }
}