using System;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class InstallerPriorityAttribute : Attribute
    {
        public const int DefaultPriority = 100;

        public int Priority { get; }

        public InstallerPriorityAttribute(int priority)
        {
            Priority = priority;
        }
    }
}