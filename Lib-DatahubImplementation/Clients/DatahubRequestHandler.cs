using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib_DatahubImplementation.Clients
{
    public class DatahubRequestHandler : DelegatingHandler
    {
        private IDatahubTokenGenerator TokenGenerator { get; }
        private DatahubLoginOptions Configuration { get; }

        public DatahubRequestHandler(IDatahubTokenGenerator tokenGenerator, IOptions<DatahubLoginOptions> configuration) : base()
        {
            TokenGenerator = tokenGenerator;
            Configuration = configuration.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await TokenGenerator.PostTokenAsync();
            request.Headers.Authorization = new(token.TokenType ?? "", token.AccessToken);
            request.Headers.Add("Ocp-Apim-Subscription-Key", Configuration.ClientSubscription);
            request.Headers.Add("Cache-Control", "no-cache");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
