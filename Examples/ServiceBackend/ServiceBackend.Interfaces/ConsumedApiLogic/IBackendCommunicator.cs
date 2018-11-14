namespace ServiceBackend.Interfaces.ConsumedApiLogic
{
    public interface IBackendCommunicator<TServiceRequest, TServiceResponse>
    {
        TServiceResponse RequestService(TServiceRequest request);
    }
}