using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SoberSoftware.CastleWindsor.Installation.SelectionCriteria
{
    public class AlwaysTrue : ISelectionCriterion
    {
        public bool IsTrue()
        {
            return true;
        }
    }
}