using Lib_DatahubImplementation.Models;

namespace Lib_DatahubImplementation.Services
{
    public interface ILoginProviderService
    {
        Task<AzureLoginResponseModel> GetTokenAsync();
    }

    public class LoginProviderService : ILoginProviderService
    {
        private LoginService Login { get; set; }

        public LoginProviderService(LoginService loginService)
        {
            Login = loginService;
        }

        public async Task<AzureLoginResponseModel> GetTokenAsync()
        {
            return await Login.PostTokenAsync();
        }
    }
}
