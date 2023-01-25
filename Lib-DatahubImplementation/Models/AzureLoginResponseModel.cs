using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models
{
    public class AzureLoginResponseModel
    {
        [JsonProperty(PropertyName = "token_type")]
        [OpenApiProperty(Description = "The token type")]
        public string? TokenType{ get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        [OpenApiProperty(Description = "This token expires in x seconds")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "ext_expires_in")]
        public int ExtExpiresIn{ get; set; }

        [JsonProperty(PropertyName = "expires_on")]
        [OpenApiProperty(Description = "This token expires on x (timestamp)")]
        public int ExpiresOn{ get; set; }

        [JsonProperty(PropertyName = "not_before")]
        [OpenApiProperty(Description = "This token doesn't expire before x (timestamp)")]
        public int NotBefore { get; set; }

        [JsonProperty(PropertyName = "resource")]
        [OpenApiProperty(Description = "The token resource")]
        public string? Resource { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        [OpenApiProperty(Description = "The famous access token")]
        public string? AccessToken { get; set; }
    }
}
