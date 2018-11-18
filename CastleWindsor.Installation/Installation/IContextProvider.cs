namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public interface IContextProvider<T>
    {
        T GetContext();
    }
}