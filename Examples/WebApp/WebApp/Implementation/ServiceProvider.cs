using System;
using ServiceBackend.Interfaces;

namespace WebApp.Implementation
{
    public class ServiceProvider : IServiceProvider<string, int>
    {
        public int PerformService(string serviceData)
        {
            return 1;
        }
    }
}