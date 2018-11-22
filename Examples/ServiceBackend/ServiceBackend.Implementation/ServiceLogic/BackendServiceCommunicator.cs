using System;
using Newtonsoft.Json;
using ServiceBackend.Implementation.BusinessLogic;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;
using ServiceBackend.Interfaces.Logging;

namespace ServiceBackend.Implementation.ServiceLogic
{
    public class BackendServiceCommunicator : IBackendCommunicator<ServiceRequest, ServiceResponse>
    {
        private readonly IBackendRequestSender<BackendServiceRequest, BackendServiceResponse> backendRequestSender;

        private readonly IBackendRequestTranslator<ServiceRequest, BackendServiceRequest> backendRequestTranslator;

        private readonly IBackendResponseTranslator<BackendServiceResponse, ServiceResponse> backendResponseTranslator;

        private readonly ILogger logger;

        public BackendServiceCommunicator(
            IBackendRequestTranslator<ServiceRequest, BackendServiceRequest> backendRequestTranslator,
            IBackendRequestSender<BackendServiceRequest, BackendServiceResponse> backendRequestSender,
            IBackendResponseTranslator<BackendServiceResponse, ServiceResponse> backendResponseTranslator,
            ILogger logger)
        {
            this.backendRequestTranslator = backendRequestTranslator;
            this.backendRequestSender = backendRequestSender;
            this.backendResponseTranslator = backendResponseTranslator;
            this.logger = logger;
        }

        public ServiceResponse RequestService(ServiceRequest request)
        {
            logger.LogInformation("Translating request.");
            BackendServiceRequest serviceRequest = backendRequestTranslator.TranslateRequest(request);
            LogTranslatedRequest(serviceRequest);

            logger.LogInformation("Sending request to service.");
            BackendServiceResponse serviceResponse = backendRequestSender.SendRequest(serviceRequest);
            LogServiceResponse(serviceResponse);

            logger.LogInformation("Translating response from service.");
            ServiceResponse translatedResponse = backendResponseTranslator.TranslateResponse(serviceResponse);
            LogTranslatedREsponse(translatedResponse);
            return translatedResponse;
        }

        private void LogTranslatedREsponse(ServiceResponse translatedResponse)
        {
            string serviceResponseAsJson = JsonConvert.SerializeObject(translatedResponse, Formatting.Indented);
            logger.LogInformation($"Translated the following response:{Environment.NewLine}{serviceResponseAsJson}");
        }

        private void LogServiceResponse(BackendServiceResponse serviceResponse)
        {
            string serviceResponseAsJson = JsonConvert.SerializeObject(serviceResponse, Formatting.Indented);
            logger.LogInformation($"Received the following response from service:{Environment.NewLine}{serviceResponseAsJson}");
        }

        private void LogTranslatedRequest(BackendServiceRequest serviceRequest)
        {
            string serviceRequestAsJson = JsonConvert.SerializeObject(serviceRequest, Formatting.Indented);
            logger.LogInformation($"Translated the following service request:{Environment.NewLine}{serviceRequestAsJson}");
        }
    }
}