using Microsoft.Extensions.Configuration;

namespace Lib_DatahubImplementation.Clients
{
    /// <summary>
    /// Options used by the requests, such as client id, client subscription, ...
    /// </summary>
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

        /// <summary>
        /// Handles the properties assignation from an <see cref="IConfiguration"/> instance.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance to get the parameters from.</param>
        public void AssignFromConfig(IConfiguration configuration)
        {
            BaseUrl = configuration["base_url"];
            LoginUrl = configuration["login_url"];
            InfoVehicleIdUrl = configuration["info_vehicle_id_url"];
            ClientSubscription = configuration["client_subscription"];
            ClientId = configuration["client_id"];
            ClientSecret = configuration["client_secret"];
            ClientResource = configuration["client_resource"];
            GrantType = "client_credentials";
        }

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
