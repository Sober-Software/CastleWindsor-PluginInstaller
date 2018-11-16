using System.Collections.Generic;
using System.Reflection;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public class DefaultPluginAssembliesProvider : IPluginAssembliesProvider
    {
        public IEnumerable<Assembly> GetAssemblies()
        {
            return new List<Assembly>();
        }
    }
}