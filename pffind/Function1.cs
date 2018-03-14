
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;

using Newtonsoft.Json;

namespace pffind
{
    public static class Function1
    {
        [FunctionName("pffind")]
        public static async Task<string> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string searchfor = req.Query["searchfor"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic _data = JsonConvert.DeserializeObject(requestBody);
            searchfor = searchfor ?? _data?.name;

            //If no query parameter added
            if (searchfor == null)
            {
                var response = new response()
                {
                    statusCode = HttpStatusCode.BadRequest.ToString(),
                    body = "No query parameter for 'searchfor' was provided"
                };
                return response.body;
            }

            //Search for the data
            PFFind pf = new PFFind();
            List<PFFind.result> data = await pf.Find(searchfor);

            if (data.Count >= 1)
            {
                //Response
                var response = new response()
                {
                    statusCode = HttpStatusCode.OK.ToString(),
                    body = JsonConvert.SerializeObject(data, Formatting.Indented)
                };
                return response.body;
            }
            else
            {
                //Response
                var response = new response()
                {
                    statusCode = HttpStatusCode.BadRequest.ToString(),
                    body = JsonConvert.SerializeObject("No data found", Formatting.Indented)
                };
                return response.body;
            }
        }

        public class response
        {
            public string statusCode { get; set; }
            public string body { get; set; }
        }
    }
}
