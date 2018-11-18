using System.Reflection;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace WebApp
{
    public class WebAppRegistration : IMainAssemblyProvider
    {
        public Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}