using Api_DatahubImplementation;
using Lib_DatahubImplementation.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using System.Net.Http;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Api_DatahubImplementation
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<ILoginProviderService, LoginProviderService>();
            builder.Services.AddHttpClient<LoginService>((httpClient) =>
            {
                httpClient.BaseAddress = new(""); // chercher le fichier local.settings.json
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddHttpMessageHandler<Object>(); // voir func-datahub-apis
            builder.Services.AddTransient<IInfoVehicleService, InfoVehicleService>();
        }
    }
}
