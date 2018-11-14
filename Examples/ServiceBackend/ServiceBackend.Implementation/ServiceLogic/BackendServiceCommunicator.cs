using ServiceBackend.Implementation.BusinessLogic;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.Implementation.ServiceLogic
{
    public class BackendServiceCommunicator : IBackendCommunicator<ServiceRequest, ServiceResponse>
    {
        private readonly IBackendRequestSender<BackendServiceRequest, BackendServiceResponse> backendRequestSender;

        private readonly IBackendRequestTranslator<ServiceRequest, BackendServiceRequest> backendRequestTranslator;

        private readonly IBackendResponseTranslator<BackendServiceResponse, ServiceResponse> backendResponseTranslator;

        public BackendServiceCommunicator(
            IBackendRequestTranslator<ServiceRequest, BackendServiceRequest> backendRequestTranslator,
            IBackendRequestSender<BackendServiceRequest, BackendServiceResponse> backendRequestSender,
            IBackendResponseTranslator<BackendServiceResponse, ServiceResponse> backendResponseTranslator)
        {
            this.backendRequestTranslator = backendRequestTranslator;
            this.backendRequestSender = backendRequestSender;
            this.backendResponseTranslator = backendResponseTranslator;
        }

        public ServiceResponse RequestService(ServiceRequest request)
        {
            BackendServiceRequest serviceRequest = backendRequestTranslator.TranslateRequest(request);
            BackendServiceResponse serviceResponse = backendRequestSender.SendRequest(serviceRequest);
            return backendResponseTranslator.TranslateResponse(serviceResponse);
        }
    }
}