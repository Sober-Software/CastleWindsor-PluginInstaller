using System;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor;

namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public static class Registrator
    {
        private static WindsorContainer containerInstance;

        private static WindsorContainer ContainerInstance
        {
            get
            {
                if (containerInstance == null)
                {
                    containerInstance = new WindsorContainer();
                    containerInstance.Kernel.ComponentRegistered += LogRegistration;
                    containerInstance.Kernel.ComponentCreated += LogComponentCreation;
                }

                return containerInstance;
            }
        }

        public static void LogComponentCreation(ComponentModel model, object o)
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

        public static void LogRegistration(string key, IHandler handler)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Registered {key} for {handler.ComponentModel.Services.First().Name}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}