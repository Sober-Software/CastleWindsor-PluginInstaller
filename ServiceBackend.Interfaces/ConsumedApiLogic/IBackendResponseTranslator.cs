namespace ServiceBackend.Interfaces.ConsumedApiLogic
{
    public interface IBackendResponseTranslator<TApiResponse, TTranslatedResponse>
    {
        TTranslatedResponse TranslateResponse(TApiResponse serviceResponse);
    }
}