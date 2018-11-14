﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SoberSoftware.CastleWindsor.Installation.Registration;

namespace ServiceBackend.Implementation.Installation
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Registrator.RegisterThisAssembly(container);
        }
    }
}