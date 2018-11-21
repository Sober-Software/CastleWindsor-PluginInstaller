namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public interface ISelectionCriterion
    {
        bool IsTrue();
    }

    public interface ISelectionCriterion<T> : ISelectionCriterion where T : class
    {
    }
}