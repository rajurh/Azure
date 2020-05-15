using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SwaggerUIAzureFunc.Models;

namespace SwaggerUIAzureFunc
{
    public class SwaggerDemos
    {
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
        [FunctionName("GetProducts")]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
        [FunctionName("GetProductsById")]
        public Task<IActionResult> GetProductById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetProductsById/{id}")]
            HttpRequest request, int id)
        {
            return Task.FromResult<IActionResult>(new OkObjectResult(new Product()));
        }
    }

  
}
