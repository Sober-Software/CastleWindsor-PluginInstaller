using System.Collections.Generic;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public class DefaultPluginAssemblyProvider : IPluginAssemblyProvider
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            return new List<string>();
        }
    }
}