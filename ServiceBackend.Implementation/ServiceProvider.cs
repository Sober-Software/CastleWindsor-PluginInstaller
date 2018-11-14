using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces;
using ServiceBackend.Interfaces.BusinessLogic;

namespace ServiceBackend.Implementation
{
    public class ServiceProvider : IServiceProvider<string, BusinessResponse>
    {
        private readonly ICommunicator<string, ServiceResponse> communicator;

        private readonly IResponseProcessor<ServiceResponse, BusinessResponse> responseProcessor;

        public ServiceProvider(ICommunicator<string, ServiceResponse> communicator,
            IResponseProcessor<ServiceResponse, BusinessResponse> responseProcessor)
        {
            this.communicator = communicator;
            this.responseProcessor = responseProcessor;
        }

        public BusinessResponse PerformService(string serviceData)
        {
            ServiceResponse response = communicator.RequestService(serviceData);
            return responseProcessor.ProcessResponse(response);
        }
    }
}