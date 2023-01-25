using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models
{
    public class VehicleData
    {
        [JsonProperty("bodyType", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Vehicle body type as plain text : Break, Berline, ...")]
        public string BodyType { get; set; }

        [JsonProperty("bodyTypeRegDoc", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Vehicle body type as per the registration document")]
        public string BodyTypeRegDoc { get; set; }

        [JsonProperty("brand", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Vehicle maker")]
        public string Brand { get; set; }

        [JsonProperty("co2Norm", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Vehicle CO2 norm used to determine the CO2 emission level")]
        public string Co2Norm { get; set; }

        [JsonProperty("co2", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Vehicle CO2 emission level")]
        public int? Co2 { get; set; }

        [JsonProperty("color", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Vehicle color")]
        public string Color { get; set; }

        [JsonProperty("critairNorm", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Critair Norm as plain text")]
        public string CritairNorm { get; set; }

        [JsonProperty("cylinder", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Cylinder")]
        public int? Cylinder { get; set; }

        [JsonProperty("dateVehicleFirstRegistered", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Date Vehicle First Registered")]
        public DateTimeOffset? DateVehicleFirstRegisteredFixed { get; set; }
        [JsonIgnore]
        public DateTime? DateVehicleFirstRegistered { get; set; }

        [JsonProperty("dateVehicleRegistered", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Date Vehicle Last Registered")]
        public DateTimeOffset? DateVehicleRegisteredFixed { get; set; }
        [JsonIgnore]
        public DateTime? DateVehicleRegistered { get; set; }

        [JsonProperty("deliveryCountry", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "ISO Country code of the last country where the vehicle has been delivered by the manufacturer")]
        public string DeliveryCountry { get; set; }

        [JsonProperty("deliveryDate", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Date at wich the vehicle has been delivered by the manufacturer")]
        public DateTimeOffset? DeliveryDateFixed { get; set; }
        [JsonIgnore]
        public DateTime? DeliveryDate { get; set; }

        [JsonProperty("driveWheelConfiguration", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Drive Wheel Configuration")]
        public string DriveWheelConfiguration { get; set; }

        [JsonProperty("driveType", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Drive Type")]
        public string DriveType { get; set; }

        [JsonProperty("engineKW", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Engine KW")]
        public int? EngineKW { get; set; }

        [JsonProperty("euroNorm", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Euro norm as plain text")]
        public string EuroNorm { get; set; }

        [JsonProperty("euroNormRegDoc", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Euro norm as per the registration document")]
        public string EuroNormRegDoc { get; set; }

        [JsonProperty("fuelType", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Fuel type in plain text")]
        public string FuelType { get; set; }

        [JsonProperty("fuelTypeRegDoc", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Fuel Type as per the registration document")]
        public string FuelTypeRegDoc { get; set; }

        [JsonProperty("gearType", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Gear Type")]
        public string GearType { get; set; }

        [JsonProperty("gearNum", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Gear Num")]
        public int? GearNum { get; set; }

        [JsonProperty("height", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Height")]
        public double? Height { get; set; }

        [JsonProperty("horsePowerCh", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Horse Power Ch")]
        public double? HorsePowerCh { get; set; }

        [JsonProperty("horsePowerCv", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Horse Power Cv")]
        public double? HorsePowerCv { get; set; }

        [JsonProperty("lastRegistrationCountry", Required = Required.Always, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "ISO Country code of the last country where the vehicle has been registred")]
        public string LastRegistrationCountry { get; set; }

        [JsonProperty("length", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Length")]
        public double? Length { get; set; }

        [JsonProperty("licensePlate", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "License plate")]
        public string LicensePlate { get; set; }

        [JsonProperty("loadWeight", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Load weight")]
        public int? LoadWeight { get; set; }

        [JsonProperty("model", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Vehicule model")]
        public string Model { get; set; }

        [JsonProperty("natCode", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Eurotax NatCode of the vehicule")]
        public int? NatCode { get; set; }

        [JsonProperty("numberOfDoors", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Price New Net")]
        public int? NumberOfDoors { get; set; }

        [JsonProperty("priceNewGross", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Price New Gross")]
        public decimal? PriceNewGross { get; set; }

        [JsonProperty("priceNewNet", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Price New Net")]
        public decimal? PriceNewNet { get; set; }

        [JsonProperty("modelYear", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Year of the date of production")]
        public int? ModelYear { get; set; }

        [JsonProperty("productionDate", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Production Date")]
        public DateTimeOffset? ProductionDateFixed { get; set; }
        [JsonIgnore]
        public DateTime? ProductionDate { get; set; }

        [JsonProperty("productionDateFrom", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Production Date From")]
        public DateTimeOffset? ProductionDateFromFixed { get; set; }
        [JsonIgnore]
        public DateTime? ProductionDateFrom { get; set; }

        [JsonProperty("productionDateTo", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Production Date To")]
        public DateTimeOffset? ProductionDateToFixed { get; set; }
        [JsonIgnore]
        public DateTime? ProductionDateTo { get; set; }

        [JsonProperty("standardEquipments", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Standard equipments")]
        public List<VehicleOption> StandardEquipments { get; set; }

        [JsonProperty("seatingCapacity", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Seating capacity")]
        public int? SeatingCapacity { get; set; }

        [JsonProperty("segment", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Segment")]
        public string Segment { get; set; }

        [JsonProperty("typeCode", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "That is CG CNIT in FR")]
        public string TypeCode { get; set; }

        [JsonProperty("typeDescription", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "That is Maker specific Model Type : Modus TCE 100 eco2 Expression")]
        public string TypeDescription { get; set; }

        [JsonProperty("type", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Generic type : VP, VU, ...")]
        public string Type { get; set; }

        [JsonProperty("typeRegDoc", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Type as per the Reg Doc - VP, VASP, ...")]
        public string TypeRegDoc { get; set; }

        [JsonProperty("uniquelyMatched", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Uniquely matched")]
        public bool? UniquelyMatched { get; set; }

        [JsonProperty("vin", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "VIN")]
        public string Vin { get; set; }

        [JsonProperty("width", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Width in cm")]
        public double? Width { get; set; }

        [JsonProperty("weight", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Populate)]
        [OpenApiProperty(Description = "Weight in Kg")]
        public int? Weight { get; set; }
    }
}
