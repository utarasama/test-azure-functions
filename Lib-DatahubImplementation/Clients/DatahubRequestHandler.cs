using Lib_DatahubImplementation.Models.AzureLoginResponses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Lib_DatahubImplementation.Clients
{
    /// <summary>
    /// Request handler for any <c>SendAsync</c> executed with a token.
    /// </summary>
    public class DatahubRequestHandler : DelegatingHandler
    {
        /// <summary>
        /// Used to get a token from cache or to generate a new one.
        /// </summary>
        private readonly IDatahubTokenGenerator _tokenGenerator;
        private readonly DatahubLoginOptions _configuration;

        public DatahubRequestHandler(IDatahubTokenGenerator tokenGenerator, IOptions<DatahubLoginOptions> configuration) : base()
        {
            _tokenGenerator = tokenGenerator;
            _configuration = configuration.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var loginResponse = await _tokenGenerator.PostTokenAsync();
            if (loginResponse.IsSuccessStatusCode)
            {
                // Lecture du stream d'une autre manière car il a déjà été lu ici à l'aide de ReasAsAsync()
                var tokenString = await loginResponse.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<AzureLoginSuccessResponseModel>(tokenString);

                request.Headers.Authorization = new(token.TokenType ?? "", token.AccessToken);
                request.Headers.Add("Ocp-Apim-Subscription-Key", _configuration.ClientSubscription);
                request.Headers.Add("Cache-Control", "no-cache");

                return await base.SendAsync(request, cancellationToken);
            }
            return new HttpResponseMessage { StatusCode = loginResponse.StatusCode };
        }
    }
}
