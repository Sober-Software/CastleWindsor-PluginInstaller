using ServiceBackend.Implementation.BusinessLogic;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.Implementation.ServiceLogic
{
    public class BackendRequestTranslator : IBackendRequestTranslator<ServiceRequest, BackendServiceRequest>
    {
        public BackendServiceRequest TranslateRequest(ServiceRequest request)
        {
            return new BackendServiceRequest
            {
                fieldS1A = request.DataField.ToUpper()
            };
        }
    }
}