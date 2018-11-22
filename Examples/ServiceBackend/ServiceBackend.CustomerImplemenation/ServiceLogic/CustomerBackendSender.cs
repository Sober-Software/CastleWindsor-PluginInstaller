using System;
using ServiceBackend.Implementation.DataType;
using ServiceBackend.Interfaces.ConsumedApiLogic;

namespace ServiceBackend.CustomerImplemenation.ServiceLogic
{
    public class CustomerBackendSender : IBackendRequestSender<BackendServiceRequest, BackendServiceResponse>
    {
        public BackendServiceResponse SendRequest(BackendServiceRequest serviceRequest)
        {
            throw new Exception("Something went wrong.");
        }
    }
}