using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models
{
    public class VehicleOption
    {
        [JsonProperty("name", Required = Required.Always, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Name { get; set; }

        [JsonProperty("priceNewNet", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        public decimal? PriceNewNet { get; set; }

        [JsonProperty("priceNewGross", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        public decimal? PriceNewGross { get; set; }


        public static List<VehicleOption>? VehicleOptionsFromStringArray(string[] options)
        {
            if (options == null)
                return null;
            List<VehicleOption> outOptions = new();
            foreach (string itemName in options)
            {
                outOptions.Add(new VehicleOption() { Name = itemName });
            }

            if (outOptions.Count == 0)
                return null;
            else
                return outOptions;
        }
    }
}
