using System;
using ServiceBackend.Interfaces;

namespace WebApp.Implementation
{
    public class SecondService : IServiceProvider<string, int>
    {
        public int PerformService(string serviceData)
        {
            return 4;
        }
    }
}