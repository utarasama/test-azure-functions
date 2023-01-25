using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using Lib_DatahubImplementation.Services;
using Lib_DatahubImplementation.Models;
using Newtonsoft.Json;

namespace Api_DatahubImplementation
{
    public class EndPoint
    {
        private readonly ILoginProviderService _loginService;
        private readonly IInfoVehicleService _infoVehicleService;

        public EndPoint(ILoginProviderService loginService, IInfoVehicleService infoVehicleService)
        {
            _loginService = loginService;
            _infoVehicleService = infoVehicleService;
        }

        [FunctionName("GetToken")]
        [OpenApiOperation(operationId: "GetToken", tags: new[] { "Authentication" })]
        //[OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "token", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(AzureLoginResponseModel), Description = "The token")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(string), Description = "Product not found.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(string), Description = "Error in request parameters.")]
        public async Task<IActionResult> GetToken(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "login")] HttpRequest req)
        {            
            var taskResponse = await _loginService.GetTokenAsync();   
            return new OkObjectResult(taskResponse);
        }

        [FunctionName("GetInfoVehicleById")]
        [OpenApiOperation(operationId: "GetInfoVehicleById", tags: new[] { "InfoVehicle" })]
        [OpenApiRequestBody("application/json", typeof(InfoVehicleRequestModel), Description = "The JSON describing the vehicle informations.", Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(InfoVehicleResponseModel), Description = "The vehicle informations")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(string), Description = "Vehicle not found.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(string), Description = "Error in request parameters.")]
        public async Task<IActionResult> GetInfoVehicleById(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "InfoVehicle/Id")] HttpRequest req)
        {
            string bodyString = await req.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<InfoVehicleRequestModel>(bodyString);
            var taskResponse = await _infoVehicleService.PostVehicleByIdAsync(body);
            
            return new OkObjectResult(taskResponse);
        }
    }
}
