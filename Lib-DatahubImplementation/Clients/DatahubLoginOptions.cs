using System.Configuration;

namespace Lib_DatahubImplementation.Clients
{
    public class DatahubLoginOptions
    {
        public string BaseUrl { get; set; }
        public string LoginUrl { get; set; }
        public string InfoVehicleIdUrl { get; set; }
        public string ClientSubscription { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientResource { get; set; }
        public string GrantType { get; set; }

        public override string ToString()
        {
            return $"client_id={ClientId}" +
                $"&client_secret={ClientSecret}" +
                $"&grant_type={GrantType}" +
                $"&resource={ClientResource}";
        }

        public static implicit operator string(DatahubLoginOptions obj)
        {
            return obj.ToString();
        }
    }
}
