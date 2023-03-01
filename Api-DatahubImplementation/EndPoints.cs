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
using Lib_DatahubImplementation.Models.InfoVehicleResponses;
using Lib_DatahubImplementation.Models.AzureLoginResponses;

namespace Api_DatahubImplementation
{
    public class EndPoints
    {
        private readonly ILoginService _loginService;
        private readonly IInfoVehicleService _infoVehicleService;

        public EndPoints(ILoginService loginService, IInfoVehicleService infoVehicleService)
        {
            _loginService = loginService;
            _infoVehicleService = infoVehicleService;
        }

        /// <summary>
        /// The purpose of this endpoint is to get a token from the Datahub API.
        /// </summary>
        /// <param name="req">The <c>GET</c> request, useless in this case because we don't need any parameter.</param>
        /// <returns>An <see cref="AzureLoginSuccessResponseModel"/> containing the <c>acess_token</c> and some informations about it.</returns>
        [FunctionName("GetToken")]
        [OpenApiOperation(operationId: "GetToken", tags: new[] { "Authentication" })]
        //[OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "token", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(AzureLoginSuccessResponseModel), Description = "The token.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Unauthorized, contentType: "application/json", bodyType: typeof(AzureLoginFailureResponseModel), Description = "Unauthirozed to login.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(AzureLoginFailureResponseModel), Description = "Error in request parameters.")]
        public async Task<IActionResult> GetToken(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "login")] HttpRequest req)
        {            
            var taskResponse = await _loginService.PostTokenAsync();
            string jsonString = await taskResponse.Content.ReadAsStringAsync();
            AzureLoginResponseModel token;
            if (taskResponse.IsSuccessStatusCode)
            {
                token = JsonConvert.DeserializeObject<AzureLoginSuccessResponseModel>(jsonString);
            }
            else 
            {
                token = JsonConvert.DeserializeObject<AzureLoginFailureResponseModel>(jsonString);
            }
            return new ObjectResult(token)
            {
                StatusCode = (int?)taskResponse.StatusCode
            };
        }

        /// <summary>
        /// The purpose of this endpoint is to get the informations of a vehicle based on some body parameters.
        /// </summary>
        /// <param name="req">The request containing the body parameters, useful in this case.</param>
        /// <returns>The informations of the desired vehicle in an <see cref="InfoVehicleSuccessResponseModel"/>.</returns>
        [FunctionName("GetInfoVehicleById")]
        [OpenApiOperation(operationId: "GetInfoVehicleById", tags: new[] { "InfoVehicle" })]
        [OpenApiRequestBody("application/json", typeof(InfoVehicleRequestModel), Description = "The JSON describing the vehicle informations.", Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(InfoVehicleSuccessResponseModel), Description = "The vehicle informations")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(InfoVehicleFailureResponseModel), Description = "Vehicle not found.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(InfoVehicleFailureResponseModel), Description = "Error in request parameters.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Unauthorized, contentType: "application/json", bodyType: typeof(InfoVehicleFailureResponseModel), Description = "Invalid token.")]
        public async Task<IActionResult> GetInfoVehicleById(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "InfoVehicle/Id")] HttpRequest req)
        {
            string bodyString = await req.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<InfoVehicleRequestModel>(bodyString);
            var taskResponse = await _infoVehicleService.PostVehicleByIdAsync(body);

            InfoVehicleResponseModel infoVehicle;
            string jsonString = await taskResponse.Content.ReadAsStringAsync();
            if (taskResponse.IsSuccessStatusCode)
            {
                infoVehicle = JsonConvert.DeserializeObject<InfoVehicleSuccessResponseModel>(jsonString);
            }
            else
            {
                infoVehicle = JsonConvert.DeserializeObject<InfoVehicleFailureResponseModel>(jsonString);
            }
            return new ObjectResult(infoVehicle)
            {
                StatusCode = (int?)taskResponse.StatusCode
            };
        }
    }
}
