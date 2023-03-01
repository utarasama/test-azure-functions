using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models.InfoVehicleResponses
{
    public class InfoVehicleSuccessResponseModel : InfoVehicleResponseModel
    {
        [JsonProperty("vehicleData")]
        public VehicleData VehicleData { get; set; }

        [JsonProperty("potentialVehicles")]
        public List<PotentialVehicle> PotentialVehicles { get; set; }
    }
}
