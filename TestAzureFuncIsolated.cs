using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace LearnAzureFunction2
{
    public static class TestAzureFuncIsolated
    {
        [Function("TestAzureFuncIsolated")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            // below code taken from diagservice project, CpuTask method 
            int[] num = new int[1000000];
            Random rnd = new Random();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int i = 0;
            // log.LogInformation("C# HTTP trigger function about to start inefficient sort.");
            while (true)
            {
                if (i > 999999)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                num[i] = rnd.Next(0, 999999);
                Array.Sort(num);
                watch.Stop();
                if (watch.ElapsedMilliseconds > 60000)
                {
                    // return new OkObjectResult($"The slow sort has stopped. Here is PID: {Process.GetCurrentProcess().Id}");

                    var response = req.CreateResponse(HttpStatusCode.OK);
                    response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                    response.WriteString("Finished!");

                    return response;
                }
                watch.Start();
            }
        }
    }
}
