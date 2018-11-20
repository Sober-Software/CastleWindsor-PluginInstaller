using System;
using ServiceBackend.Interfaces.Logging;

namespace SB_AppRunner.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}