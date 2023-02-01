using Lib_DatahubImplementation.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Text;

namespace Lib_DatahubImplementation.Clients
{
    public interface IDatahubTokenGenerator
    {
        Task<AzureLoginResponseModel> PostTokenAsync();
    }

    public class DatahubTokenGenerator : IDatahubTokenGenerator
    {
        private HttpClient Client { get; }
        private DatahubLoginOptions Configuration { get; }
        private IMemoryCache MyMemoryCache { get; }
        private readonly string _tokenCacheKey = "azureLoginResponse";
        public DatahubTokenGenerator(HttpClient client, IOptions<DatahubLoginOptions> configuration, IMemoryCache memoryCache)
        {
            Client = client;
            Configuration = configuration.Value;
            MyMemoryCache = memoryCache;
        }

        public async Task<AzureLoginResponseModel> PostTokenAsync()
        {
            if (MyMemoryCache.TryGetValue<AzureLoginResponseModel>(_tokenCacheKey, out var azureLoginResponse))
            {
                // Await ici car tous les chemins de retour doivent en contenir au moins un
                return await Task.FromResult(azureLoginResponse);
            }
            try
            {
                var httpRequest = CreateTokenRequest();
                var loginRes = await Client.SendAsync(httpRequest);

                // ReadAsAsync dans Microsoft.AspNet.WebApi.Client
                var loginResponse = await loginRes.Content.ReadAsAsync<AzureLoginResponseModel>();
                MyMemoryCache.Set(_tokenCacheKey, loginResponse, DateTimeOffset.Now.AddSeconds(loginResponse.ExpiresIn));
                return loginResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates the token request.
        /// </summary>
        /// <returns>The token request, ready to be sent.</returns>
        private HttpRequestMessage CreateTokenRequest()
        {
            Uri loginUri = new(Configuration.LoginUrl, UriKind.Relative);
            var stringContent = new StringContent(Configuration, Encoding.UTF8, "application/x-www-form-urlencoded");
            stringContent.Headers.Add("Ocp-Apim-Subscription-Key", Configuration.ClientSubscription);

            return new HttpRequestMessage(HttpMethod.Post, loginUri)
            {
                Content = stringContent
            };
        }
    }
}
