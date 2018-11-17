using System.Collections.Generic;
using System.Reflection;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    internal class DefaultPluginAssembliesProvider : IPluginAssembliesProvider
    {
        public IEnumerable<Assembly> GetAssemblies()
        {
            return new List<Assembly>();
        }
    }
}