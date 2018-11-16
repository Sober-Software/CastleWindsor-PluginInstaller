using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace MT_AppRunner.Installation
{
    public class PluginRegistration : IPluginAssembliesProvider
    {
        public IEnumerable<Assembly> GetAssemblies()
        {
            return new List<Assembly>
            {
                Assembly.LoadFrom(Path.Combine(Directory.GetCurrentDirectory(), "Customer.CountryRoad.dll")),
                Assembly.LoadFrom(Path.Combine(Directory.GetCurrentDirectory(), "Customer.Yoplait.dll"))
            };
        }
    }
}