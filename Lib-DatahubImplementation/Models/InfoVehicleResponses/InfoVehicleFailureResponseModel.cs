using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models.InfoVehicleResponses
{
    public class InfoVehicleFailureResponseModel : InfoVehicleResponseModel
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
