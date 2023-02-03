using Lib_DatahubImplementation.Clients;

namespace Lib_DatahubImplementation.Services
{
    public interface ILoginService
    {
        Task<HttpResponseMessage> PostTokenAsync();
    }

    public class LoginService : ILoginService
    {
        private readonly IDatahubTokenGenerator TokenGenerator;

        public LoginService(IDatahubTokenGenerator datahubTokenGenerator)
        {
            TokenGenerator = datahubTokenGenerator;
        }

        /// <summary>
        /// Gets a token from DataHub
        /// </summary>
        /// <returns>The token object</returns>
        /// <exception cref="Exception">Exception thrown by the token generator.</exception>
        public async Task<HttpResponseMessage> PostTokenAsync()
        {
            return await TokenGenerator.PostTokenAsync();
        }
    }
}