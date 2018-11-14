namespace ServiceBackend.Interfaces.ConsumedApiLogic
{
    public interface IBackendRequestTranslator<TRequest, TTranslatedRequest>
    {
        TTranslatedRequest TranslateRequest(TRequest request);
    }
}