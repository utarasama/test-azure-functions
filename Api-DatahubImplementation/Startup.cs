using Api_DatahubImplementation;
using Lib_DatahubImplementation.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using Lib_DatahubImplementation.Clients;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Api_DatahubImplementation
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<DatahubLoginOptions>().Configure<IConfiguration>((options, configuration) =>
            {
                options.BaseUrl = configuration["base_url"];
                options.LoginUrl = configuration["login_url"];
                options.InfoVehicleIdUrl = configuration["info_vehicle_id_url"];
                options.ClientSubscription = configuration["client_subscription"];
                options.ClientId = configuration["client_id"];
                options.ClientSecret = configuration["client_secret"];
                options.ClientResource = configuration["client_resource"];
            });
            builder.Services.AddTransient<ILoginService, LoginService>();
            builder.Services.AddTransient<IDatahubTokenGenerator, DatahubTokenGenerator>();

            builder.Services.AddTransient<DatahubRequestHandler>();

            builder.Services
                .AddTransient<IInfoVehicleService, InfoVehicleService>()
                .AddHttpClient<IInfoVehicleService, InfoVehicleService>((serviceProvider, httpClient) =>
                {
                    string baseUrl = serviceProvider.GetRequiredService<IConfiguration>()["base_url"];
                    httpClient.BaseAddress = new(baseUrl);
                }).AddHttpMessageHandler<DatahubRequestHandler>();
        }
    }
}
