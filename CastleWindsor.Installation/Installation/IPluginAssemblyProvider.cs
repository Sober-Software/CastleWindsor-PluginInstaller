using System.Collections.Generic;

namespace CastleWindsor.Installation.Installation
{
    public interface IPluginAssemblyProvider
    {
        IEnumerable<string> GetAssemblyNames();
    }
}