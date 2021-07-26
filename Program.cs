using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using System;
using System.Diagnostics;

namespace LearnAzureFunction2
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("PID: {0}", Process.GetCurrentProcess().Id);
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .Build();

            host.Run();

        }
    }
}