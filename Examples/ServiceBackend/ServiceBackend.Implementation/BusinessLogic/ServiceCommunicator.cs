using Newtonsoft.Json;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.BusinessLogic;
using ServiceBackend.Interfaces.ConsumedApiLogic;
using ServiceBackend.Interfaces.Logging;

namespace ServiceBackend.Implementation.BusinessLogic
{
    public class ServiceCommunicator : ICommunicator<string, ServiceResponse>
    {
        private readonly IBackendCommunicator<ServiceRequest, ServiceResponse> backendCommunicator;

        private readonly IRequestGenerator<string, ServiceRequest> requestGenerator;

        private readonly ILogger logger;

        public ServiceCommunicator(IRequestGenerator<string, ServiceRequest> requestGenerator,
            IBackendCommunicator<ServiceRequest, ServiceResponse> backendCommunicator, ILogger logger)
        {
            this.requestGenerator = requestGenerator;
            this.backendCommunicator = backendCommunicator;
            this.logger = logger;
        }

        public ServiceResponse RequestService(string serviceData)
        {
            logger.LogInformation("Creating request.");
            ServiceRequest request = requestGenerator.GenerateServiceRequest(serviceData);
            LogRequest(request);
            return backendCommunicator.RequestService(request);
        }

        private void LogRequest(ServiceRequest request)
        {
            string requestAsJson = JsonConvert.SerializeObject(request);
            logger.LogInformation($"Generated request: {requestAsJson}");
        }
    }
}