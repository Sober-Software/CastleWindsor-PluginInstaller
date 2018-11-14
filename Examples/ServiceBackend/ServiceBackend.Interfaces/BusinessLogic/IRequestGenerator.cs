namespace ServiceBackend.Interfaces.BusinessLogic
{
    public interface IRequestGenerator<TServiceData, TServiceRequest>
    {
        TServiceRequest GenerateServiceRequest(TServiceData serviceData);
    }
}