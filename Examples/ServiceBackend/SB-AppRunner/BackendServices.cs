using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SB_AppRunner
{
    public class BackendServices : IPluginAssembliesProvider
    {
        public IEnumerable<Assembly> GetAssemblies()
        {
            return new List<Assembly>
            {
                Assembly.LoadFrom(Path.Combine(@"C:\Projects\CastleWindsor-PluginInstaller\Examples\ServiceBackend\SB-AppRunner\bin\Debug\netcoreapp2.1", "ServiceBackend.Implementation.dll")),
                Assembly.LoadFrom(Path.Combine(@"C:\Projects\CastleWindsor-PluginInstaller\Examples\ServiceBackend\SB-AppRunner\bin\Debug\netcoreapp2.1", "ServiceBackend.CustomerImplemenation.dll"))
            };
        }
    }
}