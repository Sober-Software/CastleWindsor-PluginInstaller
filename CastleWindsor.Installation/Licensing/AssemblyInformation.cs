using System;
using System.Reflection;

namespace SoberSoftware.CastleWindsor.Installation.Licensing
{
    public class AssemblyInformation
    {
        public static string GetAssemblyName()
        {
            return Assembly.GetCallingAssembly().FullName;
        }

        public static string GetAttributeValue<TAttribute>(Func<TAttribute,
            string> resolveFunc, Assembly assembly) where TAttribute : Attribute
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(TAttribute), false);

            if (attributes.Length > 0)
            {
                return resolveFunc((TAttribute) attributes[0]);
            }

            return string.Empty;
        }
    }
}