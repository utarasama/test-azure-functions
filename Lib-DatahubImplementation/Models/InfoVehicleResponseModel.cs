using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_DatahubImplementation.Models
{
    public  class InfoVehicleResponseModel
    {
        [JsonProperty("vehicleData")]
        public VehicleData VehicleData { get; set; }

        [JsonProperty("potentialVehicles")]
        public List<PotentialVehicle> PotentialVehicles { get; set; }
    }
}
