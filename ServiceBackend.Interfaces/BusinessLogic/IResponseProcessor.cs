namespace ServiceBackend.Interfaces.BusinessLogic
{
    public interface IResponseProcessor<TServiceResponse, TBusinessResponse>
    {
        TBusinessResponse ProcessResponse(TServiceResponse response);
    }
}