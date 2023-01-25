using Lib_DatahubImplementation.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Lib_DatahubImplementation.Services
{
    public interface IInfoVehicleService
    {
        Task<InfoVehicleResponseModel> PostVehicleByIdAsync(InfoVehicleRequestModel infoVehicle);
    }

    public class InfoVehicleService : IInfoVehicleService
    {
        private LoginService Login { get; set; }
        private readonly HttpClient MyHttpClient;
        private readonly IConfiguration Configuration;

        public InfoVehicleService(LoginService loginService, IConfiguration configuration, HttpClient httpClient)
        {
            Login = loginService;
            MyHttpClient = httpClient;
            Configuration = configuration;

            MyHttpClient.BaseAddress = new Uri(Configuration["base_url"]);
            MyHttpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Login and gets vehicle informations as POST request.
        /// </summary>
        /// <param name="infoVehicle">Vehicle info parameters.</param>
        /// <returns>Returns all of the specified vehicle informations.</returns>
        public async Task<InfoVehicleResponseModel> PostVehicleByIdAsync(InfoVehicleRequestModel infoVehicle)
        {
            var loginResponse = await Login.PostTokenAsync();
            Uri infoVehicleUri = new(Configuration["info_vehicle_id_url"], UriKind.Relative);
            var stringContent = new StringContent(infoVehicle.ToString(), Encoding.UTF8, "application/json");
            HttpRequestMessage request = new(HttpMethod.Post, infoVehicleUri)
            {
                Content = stringContent
            };
            request.Headers.Authorization = new(loginResponse.AccessToken);
            request.Headers.Add("Ocp-Apim-Subscription-Key", Configuration["client_subscription"]);
            request.Headers.Add("Cache-Control", "no-cache");

            var response = await MyHttpClient.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            var infoVehicleResponse = JsonConvert.DeserializeObject<InfoVehicleResponseModel>(jsonString);
            return infoVehicleResponse;
        }
    }
}
