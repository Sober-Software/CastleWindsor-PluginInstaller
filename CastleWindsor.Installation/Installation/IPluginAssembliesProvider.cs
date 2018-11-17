using System.Collections.Generic;
using System.Reflection;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public interface IPluginAssembliesProvider
    {
        IEnumerable<Assembly> GetAssemblies();
    }
}