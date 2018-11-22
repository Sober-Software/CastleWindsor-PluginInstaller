using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor.Installer;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public class InstallerPriority : InstallerFactory
    {
        public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
        {
            IOrderedEnumerable<Type> sortedInstallers = installerTypes.OrderBy(GetPriority);
            return sortedInstallers;
        }

        private int GetPriority(Type type)
        {
            InstallerPriorityAttribute attribute = type.GetCustomAttributes(typeof(InstallerPriorityAttribute), false).FirstOrDefault() as InstallerPriorityAttribute;
            return attribute?.Priority ?? InstallerPriorityAttribute.DefaultPriority;
        }
    }
}