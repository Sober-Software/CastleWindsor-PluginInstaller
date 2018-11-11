using System.Collections.Generic;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace AppRunner.Installation
{
    public class PluginRegistration : IPluginAssemblyProvider
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            return new List<string>
            {
                "Customer.CountryRoad"
            };
        }
    }
}