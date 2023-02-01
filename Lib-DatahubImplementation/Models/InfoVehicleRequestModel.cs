using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models
{
    public class InfoVehicleRequestModel
    {
        [JsonProperty("originCountry")]
        public string OriginCountry { get; set; }
        [JsonProperty("licensePlate", Required = Required.DisallowNull)]
        public string LicencePlate { get; set; }
        [JsonProperty("vin", Required = Required.DisallowNull)]
        public string Vin { get; set; }
        [JsonProperty("natCode")]
        public uint NatCode { get; set; }
        [JsonProperty("useCache")]
        public bool UseCache { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static implicit operator string(InfoVehicleRequestModel obj)
        {
            return obj.ToString();
        }
    }
}
