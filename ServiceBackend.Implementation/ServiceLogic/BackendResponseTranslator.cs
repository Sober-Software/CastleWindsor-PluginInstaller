using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.Implementation.ServiceLogic
{
    public class BackendResponseTranslator : IBackendResponseTranslator<BackendServiceResponse, ServiceResponse>
    {
        public ServiceResponse TranslateResponse(BackendServiceResponse serviceResponse)
        {
            return new ServiceResponse
            {
                First = serviceResponse.First,
                Age = serviceResponse.Age
            };
        }
    }
}