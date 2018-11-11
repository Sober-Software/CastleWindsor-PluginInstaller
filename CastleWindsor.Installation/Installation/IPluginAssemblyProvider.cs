using System.Collections.Generic;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public interface IPluginAssemblyProvider
    {
        IEnumerable<string> GetAssemblyNames();
    }
}