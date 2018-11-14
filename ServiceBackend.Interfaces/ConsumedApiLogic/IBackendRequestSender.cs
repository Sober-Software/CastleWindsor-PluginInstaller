namespace ServiceBackend.Interfaces.ConsumedApiLogic
{
    public interface IBackendRequestSender<TTranslatedRequest, TApiResponse>
    {
        TApiResponse SendRequest(TTranslatedRequest serviceRequest);
    }
}