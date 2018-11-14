using System.Collections.Generic;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SB_AppRunner
{
    public class BackendServices : IPluginAssemblyProvider
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            return new[]
            {
                "ServiceBackend.Implementation",
                "ServiceBackend.CustomerImplemenation"
            };
        }
    }
}