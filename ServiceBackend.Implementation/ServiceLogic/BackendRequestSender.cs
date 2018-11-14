using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.Implementation.ServiceLogic
{
    public class BackendRequestSender : IBackendRequestSender<BackendServiceRequest, BackendServiceResponse>
    {
        public BackendServiceResponse SendRequest(BackendServiceRequest serviceRequest)
        {
            return new BackendServiceResponse
            {
                First = "Gart",
                Last = "Jarphon",
                Age = 28,
                Nickname = "Garbo"
            };
        }
    }
}