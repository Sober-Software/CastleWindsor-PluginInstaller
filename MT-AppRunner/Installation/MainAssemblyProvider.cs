using SoberSoftware.CastleWindsor.Installation.Installation;
using SoberSoftware.CastleWindsor.Installation.Licensing;

namespace MT_AppRunner.Installation
{
    public class MainAssemblyProvider : IMainAssemblyProvider
    {
        public string GetAssemblyName()
        {
            return AssemblyInformation.GetAssemblyName();
        }
    }
}