using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models.AzureLoginResponses
{
    public class AzureLoginFailureResponseModel : AzureLoginResponseModel
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty(PropertyName = "trace_id")]
        public string TraceId { get; set; }

        [JsonProperty(PropertyName = "correlation_id")]
        public string CorrelationId { get; set; }

        [JsonProperty(PropertyName = "error_uri")]
        public string ErrorUri { get; set; }
    }
}
