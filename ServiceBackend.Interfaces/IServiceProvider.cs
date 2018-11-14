namespace ServiceBackend.Interfaces
{
    public interface IServiceProvider<TServiceData, TBusinessResponse>
    {
        TBusinessResponse PerformService(TServiceData serviceData);
    }
}