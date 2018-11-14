using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SB_AppRunner
{
    public class ImplementationProvider : IContextProvider
    {
        public string GetContext()
        {
            return Program.Implementation;
        }
    }
}