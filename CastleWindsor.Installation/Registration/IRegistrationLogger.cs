using Castle.Core;
using Castle.MicroKernel;

namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public interface IRegistrationLogger
    {
        void LogRegistration(string key, IHandler handler);

        void LogComponentCreated(ComponentModel model, object instance);
    }
}