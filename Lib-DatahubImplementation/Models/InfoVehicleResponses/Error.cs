using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Models.InfoVehicleResponses
{
    /// <summary>
    /// Modèle d'erreur pour Datahub InfoVehicle.
    /// </summary>
    public class Error
    {
        [JsonProperty(PropertyName = "Status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "InternalErrorMessage")]
        public string InternalErrorMessage { get; set; }

        [JsonProperty(PropertyName = "OperationId")]
        public string OperationId { get; set; }
    }
}
