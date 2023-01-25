using Lib_DatahubImplementation.Models;
using Microsoft.Extensions.Configuration;
using System.Runtime.Caching;
using System.Text;

namespace Lib_DatahubImplementation.Services
{
    public interface ILoginService
    {
        Task<AzureLoginResponseModel> PostTokenAsync();
    }

    public class LoginService : ILoginService
    {
        private readonly IConfiguration Configuration;
        private readonly HttpClient DatahubClient;
        private readonly string TokenCacheKey = "azureLoginResponse";


        public LoginService(IConfiguration configuration, HttpClient client)
        {
            Configuration = configuration;
            DatahubClient = client;
            DatahubClient.BaseAddress = new Uri(Configuration["base_url"]);
        }

        /// <summary>
        /// Gets a token from DataHub
        /// </summary>
        /// <returns>The token object</returns>
        /// <exception cref="Exception"></exception>
        public async Task<AzureLoginResponseModel> PostTokenAsync()
        {
            var memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(TokenCacheKey))
            {
                return (AzureLoginResponseModel)memoryCache.Get(TokenCacheKey);
            }
            else
            {
                try
                {
                    Uri loginUri = new(Configuration["login_url"], UriKind.Relative);
                    string loginBody = $"client_id={Configuration["client_id"]}" +
                        $"&client_secret={Configuration["client_secret"]}" +
                        $"&grant_type=client_credentials" +
                        $"&resource={Configuration["client_resource"]}";
                    var stringContent = new StringContent(loginBody, Encoding.UTF8, "application/x-www-form-urlencoded");

                    stringContent.Headers.Add("Ocp-Apim-Subscription-Key", Configuration["client_subscription"]);

                    var loginRes = await DatahubClient.PostAsync(loginUri, stringContent);

                    // ReadAsAsync dans Microsoft.AspNet.WebApi.Client
                    AzureLoginResponseModel loginResponse = await loginRes.Content.ReadAsAsync<AzureLoginResponseModel>();
                    memoryCache.Add(TokenCacheKey,
                        loginResponse,
                        new CacheItemPolicy()
                        {
                            AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(loginResponse.ExpiresIn)
                        });
                    return loginResponse;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}