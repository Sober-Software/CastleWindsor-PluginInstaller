using System.Reflection;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SB_AppRunner
{
    public class Registration : IMainAssemblyProvider
    {
        public Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}