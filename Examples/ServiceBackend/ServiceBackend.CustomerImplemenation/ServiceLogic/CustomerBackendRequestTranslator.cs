using ServiceBackend.Implementation.BusinessLogic;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.CustomerImplemenation.ServiceLogic
{
    public class CustomerBackendRequestTranslator : IBackendRequestTranslator<ServiceRequest, BackendServiceRequest>
    {
        public BackendServiceRequest TranslateRequest(ServiceRequest request)
        {
            return new BackendServiceRequest
            {
                fieldS1A = $"%%!@{request.DataField.ToLower()}*&%"
            };
        }
    }
}