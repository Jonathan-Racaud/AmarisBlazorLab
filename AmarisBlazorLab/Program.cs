using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AmarisBlazorLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // .ConfigureLogging(logging =>
                // {
                //     logging.ClearProviders();
                //     logging.AddConsole();
                //     logging.AddFilter(
                //       "Microsoft.AspNetCore.SignalR", LogLevel.Trace);
                //     logging.AddFilter(
                //       "Microsoft.AspNetCore.Http.Connections",
                //       LogLevel.Trace);
                // })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
