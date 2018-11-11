using System;

namespace SoberSoftware.CastleWindsor.Installation.Licensing
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ApiKeyAttribute : Attribute
    {
        public string ApiKey { get; set; }

        public ApiKeyAttribute(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}