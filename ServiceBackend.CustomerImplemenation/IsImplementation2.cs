using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace ServiceBackend.CustomerImplemenation
{
    public class IsImplementation2 : ISelectionCriterion
    {
        private readonly IContextProvider contextProvider;

        public IsImplementation2(IContextProvider contextProvider)
        {
            this.contextProvider = contextProvider;
        }

        public bool IsTrue()
        {
            return contextProvider.GetContext() == "2";
        }
    }
}