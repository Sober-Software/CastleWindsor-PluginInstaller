﻿using System.Reflection;
using SoberSoftware.CastleWindsor.Installation.Installation;

namespace MT_AppRunner.Installation
{
    public class MainAssemblyProvider : IMainAssemblyProvider
    {
        public Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}