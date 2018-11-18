using SoberSoftware.CastleWindsor.Installation.Registration;

namespace WebApp
{
    public class AlwaysTrue : ISelectionCriterion
    {
        public bool IsTrue()
        {
            return true;
        }
    }
}