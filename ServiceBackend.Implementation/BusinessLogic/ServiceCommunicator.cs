using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.BusinessLogic;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.Implementation.BusinessLogic
{
    public class ServiceCommunicator : ICommunicator<string, ServiceResponse>
    {
        private readonly IBackendCommunicator<ServiceRequest, ServiceResponse> backendCommunicator;

        private readonly IRequestGenerator<string, ServiceRequest> requestGenerator;

        public ServiceCommunicator(IRequestGenerator<string, ServiceRequest> requestGenerator,
            IBackendCommunicator<ServiceRequest, ServiceResponse> backendCommunicator)
        {
            this.requestGenerator = requestGenerator;
            this.backendCommunicator = backendCommunicator;
        }

        public ServiceResponse RequestService(string serviceData)
        {
            ServiceRequest request = requestGenerator.GenerateServiceRequest(serviceData);
            return backendCommunicator.RequestService(request);
        }
    }
}