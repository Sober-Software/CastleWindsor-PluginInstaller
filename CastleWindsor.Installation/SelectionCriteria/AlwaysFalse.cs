using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SoberSoftware.CastleWindsor.Installation.SelectionCriteria
{
    public class AlwaysFalse : ISelectionCriterion
    {
        public bool IsTrue()
        {
            return false;
        }
    }
}