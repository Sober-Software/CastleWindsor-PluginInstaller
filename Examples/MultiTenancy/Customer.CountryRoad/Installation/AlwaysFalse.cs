using SoberSoftware.CastleWindsor.Installation.Registration;

namespace Customer.CountryRoad.Installation
{
    public class AlwaysFalse : ISelectionCriterion
    {
        public bool IsTrue()
        {
            return false;
        }
    }
}