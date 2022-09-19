using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RJSY.Azure.CustomBindingAuth.Function.Bindings;
using RJSY.Azure.CustomBindingAuth.Function.Models;

namespace RJSY.Azure.CustomBindingAuth.Function
{
    public class AuthTestApi
    {
        [FunctionName("AuthTest")]
        public async Task<IActionResult> AuthTest(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test")] HttpRequest req,
            [AzureAdToken] AzureAdToken token)
        {
            if (token == null)
            {
                return new UnauthorizedResult();
            }

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
