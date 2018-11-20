using ServiceBackend.Interfaces.Logging;

namespace SB_AppRunner.Logging
{
    public class NullLogger : ILogger
    {
        public void LogInformation(string message)
        {
            // Do nothing.
        }
    }
}