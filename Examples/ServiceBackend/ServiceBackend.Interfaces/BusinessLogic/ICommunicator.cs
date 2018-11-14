namespace ServiceBackend.Interfaces.BusinessLogic
{
    public interface ICommunicator<TRequest, TResponse>
    {
        TResponse RequestService(TRequest serviceData);
    }
}