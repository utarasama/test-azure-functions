using Microsoft.Extensions.Options;

namespace Lib_DatahubImplementation.Clients
{
    public class DatahubRequestHandler : DelegatingHandler
    {
        /// <summary>
        /// Used to get a token from cache or generate a new one.
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
            var token = await _tokenGenerator.PostTokenAsync();
            request.Headers.Authorization = new(token.TokenType ?? "", token.AccessToken);
            request.Headers.Add("Ocp-Apim-Subscription-Key", _configuration.ClientSubscription);
            request.Headers.Add("Cache-Control", "no-cache");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
