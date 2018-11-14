using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.BusinessLogic;

namespace ServiceBackend.Implementation.BusinessLogic
{
    public class ServiceResponseProcessor : IResponseProcessor<ServiceResponse, BusinessResponse>
    {
        public BusinessResponse ProcessResponse(ServiceResponse response)
        {
            if (response.Age > 30)
            {
                return new UnsuccessfulResponse(new[] {"Age over 30."});
            }

            return new SuccessfulResponse(new[] {"Age under 30."});
        }
    }
}