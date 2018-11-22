using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces;
using ServiceBackend.Interfaces.BusinessLogic;
using ServiceBackend.Interfaces.Logging;

namespace ServiceBackend.Implementation
{
    public class ServiceProvider : IServiceProvider<string, BusinessResponse>
    {
        private readonly ICommunicator<string, ServiceResponse> communicator;

        private readonly IResponseProcessor<ServiceResponse, BusinessResponse> responseProcessor;

        private readonly ILogger logger;

        public ServiceProvider(ICommunicator<string, ServiceResponse> communicator,
            IResponseProcessor<ServiceResponse, BusinessResponse> responseProcessor,
            ILogger logger)
        {
            this.communicator = communicator;
            this.responseProcessor = responseProcessor;
            this.logger = logger;
        }

        public BusinessResponse PerformService(string serviceData)
        {
            logger.LogInformation("Communicating with Service.");
            ServiceResponse response = communicator.RequestService(serviceData);
            logger.LogInformation("Processing response.");
            return responseProcessor.ProcessResponse(response);
        }
    }
}