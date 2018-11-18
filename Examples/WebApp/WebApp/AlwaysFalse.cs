using SoberSoftware.CastleWindsor.Installation.Registration;

namespace WebApp
{
    public class AlwaysFalse : ISelectionCriterion
    {
        public bool IsTrue()
        {
            return false;
        }
    }
}