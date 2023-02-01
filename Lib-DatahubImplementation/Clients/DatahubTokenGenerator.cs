using Lib_DatahubImplementation.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

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
        private const string TokenCacheKey = "azureLoginResponse";
        private const string GrantType = "client_credentials";
        public DatahubTokenGenerator(HttpClient client, IOptions<DatahubLoginOptions> configuration, IMemoryCache memoryCache)
        {
            Client = client;
            Configuration = configuration.Value;
            MyMemoryCache = memoryCache;

            Client.BaseAddress = new(Configuration.BaseUrl);
        }

        public async Task<AzureLoginResponseModel> PostTokenAsync()
        {
            if (MyMemoryCache.TryGetValue<AzureLoginResponseModel>(TokenCacheKey, out var azureLoginResponse))
            {
                // Await ici car tous les chemins de retour doivent en contenir au moins un
                return await Task.FromResult(azureLoginResponse);
            }
            try
            {
                Uri loginUri = new(Configuration.LoginUrl, UriKind.Relative);
                string loginBody = $"client_id={Configuration.ClientId}" +
                    $"&client_secret={Configuration.ClientSecret}" +
                    $"&grant_type={GrantType}" +
                    $"&resource={Configuration.ClientResource}";
                var stringContent = new StringContent(loginBody, Encoding.UTF8, "application/x-www-form-urlencoded");

                stringContent.Headers.Add("Ocp-Apim-Subscription-Key", Configuration.ClientSubscription);

                var loginRes = await Client.PostAsync(loginUri, stringContent);

                // ReadAsAsync dans Microsoft.AspNet.WebApi.Client
                var loginResponse = await loginRes.Content.ReadAsAsync<AzureLoginResponseModel>();
                MyMemoryCache.Set(TokenCacheKey, loginResponse, DateTimeOffset.Now.AddSeconds(loginResponse.ExpiresIn));
                return loginResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
