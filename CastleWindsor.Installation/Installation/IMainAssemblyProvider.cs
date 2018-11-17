using System.Reflection;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public interface IMainAssemblyProvider
    {
        Assembly GetAssembly();
    }
}