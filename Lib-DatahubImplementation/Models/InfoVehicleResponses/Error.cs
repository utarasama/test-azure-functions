namespace Lib_DatahubImplementation.Models.InfoVehicleResponses
{
    /// <summary>
    /// Modèle d'erreur pour Datahub InfoVehicle.
    /// </summary>
    public class Error
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public string InternalErrorMessage { get; set; }
        public string OperationId { get; set; }
    }
}
