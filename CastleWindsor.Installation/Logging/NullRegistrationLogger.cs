using Castle.Core;
using Castle.MicroKernel;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SoberSoftware.CastleWindsor.Installation.Logging
{
    public class NullRegistrationLogger : IRegistrationLogger
    {
        public void LogComponentCreated(ComponentModel model, object instance)
        {
            // Do nothing.
        }

        public void LogRegistration(string key, IHandler handler)
        {
            // Do nothing.
        }
    }
}