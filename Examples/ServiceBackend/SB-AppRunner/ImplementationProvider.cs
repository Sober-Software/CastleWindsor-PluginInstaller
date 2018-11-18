using SoberSoftware.CastleWindsor.Installation.Installation;

namespace SB_AppRunner
{
    public class ImplementationProvider : IContextProvider<string>
    {
        public string GetContext()
        {
            return Program.Implementation;
        }
    }
}