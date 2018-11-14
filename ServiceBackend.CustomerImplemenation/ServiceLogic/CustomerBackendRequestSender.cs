using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.CustomerImplemenation.ServiceLogic
{
    public class CustomerBackendRequestSender : IBackendRequestSender<BackendServiceRequest, BackendServiceResponse>
    {
        public BackendServiceResponse SendRequest(BackendServiceRequest serviceRequest)
        {
            return new BackendServiceResponse
            {
                First = "Bart",
                Last = "Solonsa",
                Age = 55,
                Nickname = "BS"
            };
        }
    }
}