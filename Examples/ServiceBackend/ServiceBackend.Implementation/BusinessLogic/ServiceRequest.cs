using Newtonsoft.Json;

namespace ServiceBackend.Implementation.BusinessLogic
{
    public class ServiceRequest
    {
        [JsonProperty("datafield")]
        public string DataField { get; set; }
    }
}