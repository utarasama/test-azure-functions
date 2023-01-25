using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models
{
    public class InfoVehicleRequestModel
    {
        [JsonProperty("originCountry")]
        public string OriginCountry { get; set; }
        [JsonProperty("licensePlate")]
        public string LicencePlate { get; set; }
        [JsonProperty("vin")]
        public string Vin { get; set; }
        [JsonProperty("natCode")]
        public uint NatCode { get; set; }
        [JsonProperty("useCache")]
        public bool UseCache { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
