using System;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace SoberSoftware.CastleWindsor.Installation.Logging
{
    public class ConsoleRegistrationLogger : IRegistrationLogger
    {
        public void LogComponentCreated(ComponentModel model, object instance)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Resolved ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{model.ComponentName}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" as ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{model.Services.First()}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogRegistration(string key, IHandler handler)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Registered {key} for {handler.ComponentModel.Services.First().Name}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}