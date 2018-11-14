using Newtonsoft.Json;
using ServiceBackend.Interfaces.BusinessLogic;

namespace ServiceBackend.Implementation.BusinessLogic
{
    public class ServiceRequestGenerator : IRequestGenerator<string, ServiceRequest>
    {
        public ServiceRequest GenerateServiceRequest(string serviceData)
        {
            return JsonConvert.DeserializeObject<ServiceRequest>(serviceData);
        }
    }
}