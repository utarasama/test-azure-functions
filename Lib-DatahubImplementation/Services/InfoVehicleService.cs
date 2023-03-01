using Lib_DatahubImplementation.Clients;
using Lib_DatahubImplementation.Models;
using Lib_DatahubImplementation.Models.InfoVehicleResponses;
using Microsoft.Extensions.Options;
using System.Text;

namespace Lib_DatahubImplementation.Services
{
    public interface IInfoVehicleService
    {
        Task<HttpResponseMessage> PostVehicleByIdAsync(InfoVehicleRequestModel infoVehicle);
    }

    /// <summary>
    /// Service for getting any vehicle informations.
    /// </summary>
    public class InfoVehicleService : IInfoVehicleService
    {
        private readonly HttpClient Client;
        private readonly DatahubLoginOptions Configuration;

        public InfoVehicleService(IOptions<DatahubLoginOptions> configuration, HttpClient httpClient)
        {
            Client = httpClient;
            Configuration = configuration.Value;
        }

        /// <summary>
        /// Login and gets vehicle informations as POST request.
        /// </summary>
        /// <param name="infoVehicle">Vehicle info parameters.</param>
        /// <returns>Returns all of the specified vehicle informations as a <see cref="InfoVehicleResponseModel"/> object.</returns>
        public async Task<HttpResponseMessage> PostVehicleByIdAsync(InfoVehicleRequestModel infoVehicle)
        {
            var request = CreateInfoVehicleRequest(infoVehicle);
            var response = await Client.SendAsync(request);
            return response;
        }

        /// <summary>
        /// Creates the InfoVehicle request based on vehicle informations
        /// </summary>
        /// <param name="infoVehicle">The vehicle informations.</param>
        /// <returns>The request created, ready to be executed.</returns>
        private HttpRequestMessage CreateInfoVehicleRequest(InfoVehicleRequestModel infoVehicle)
        {
            Uri infoVehicleUri = new(Configuration.InfoVehicleIdUrl, UriKind.Relative);
            var stringContent = new StringContent(infoVehicle, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new(HttpMethod.Post, infoVehicleUri)
            {
                Content = stringContent
            };
            return request;
        }
    }
}
