using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models
{
    public class PotentialVehicle
    {
        [JsonProperty("natCode")]
        public int NatCode { get; set; }

        //[JsonProperty("confidence")]
        [JsonIgnore]
        public double Confidence { get; set; }

        //[JsonProperty("confidence")]
        [JsonIgnore]
        public double ConfidenceAlgolia { get; set; }

        //[JsonProperty("confidence")]
        [JsonIgnore]
        public double ConfidenceDataneo { get; set; }

        // Algolia
        [JsonProperty("brand")]
        public string Brand { get; set; }

        // Dataneo.Autovista // Algolia
        [JsonProperty("model")]
        public string Model { get; set; }

        // Algolia
        //[JsonProperty("_model2")]
        [JsonIgnore]
        public string Model2 { get; set; }

        // Dataneo.Autovista // Algolia
        [JsonProperty("typeDescription")]
        public string Version { get; set; }

        // Algolia
        //[JsonProperty("_version2")]
        [JsonIgnore]
        public string Version2 { get; set; }

        // Dataneo.Autovista // Algolia
        [JsonProperty("gearType")]
        public string Boite { get; set; }

        // Dataneo.Autovista // Algolia
        [JsonProperty("bodyType")]
        public string Carrosserie { get; set; }

        // Dataneo.Autovista // Algolia
        [JsonProperty("numberOfDoors")]
        public int Portes { get; set; }

        // Algolia
        [JsonProperty("seatingCapacity")]
        public int Sieges { get; set; }

        // Dataneo.Autovista // Algolia
        [JsonProperty("horsePowerCh")]
        public double Puissancech { get; set; }

        // Dataneo.Autovista // Algolia
        [JsonProperty("horsePowerCv")]
        public double HpFisc { get; set; }

        // Algolia
        [JsonProperty("fuelType")]
        public string FuelTypeName { get; set; }

        // Algolia
        [JsonProperty("priceNewNet")]
        public decimal NewCarNetPrice { get; set; }

        // Algolia
        [JsonProperty("priceNewGross")]
        public decimal NewCarGrossPrice { get; set; }

        // Algolia
        [JsonProperty("segment")]
        public string Seg1Cd2 { get; set; }

        // Algolia
        [JsonIgnore]
        public string SegIntCd2 { get; set; }

        // Algolia
        [JsonProperty("productionDateFrom")]
        public DateTimeOffset? ModImpBeginFixed { get; set; }
        [JsonIgnore]
        public DateTime? ModImpBegin { get; set; }


        // Algolia
        [JsonProperty("productionDateTo")]
        public DateTimeOffset? ModImpEndFixed { get; set; }
        [JsonIgnore]
        public DateTime? ModImpEnd { get; set; }
    }
}
