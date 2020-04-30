using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace LunarCalendar
{
    public class Program
    {
        #region Global
        internal readonly static string Name = "LunarCalendar";
        internal readonly static string Author = "Amemiya Shigure";
        internal readonly static string Version = "1.0.0";
        #endregion

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureKestrel(options =>
                        {
                            var config = (IConfiguration)options.ApplicationServices.GetService(typeof(IConfiguration));

                            if (bool.Parse(config["Listen:Http:Enable"]))
                            {
                                options.Listen(IPAddress.Any, int.Parse(config["Listen:Http:Port"]), option =>
                                {
                                    option.UseConnectionLogging();
                                });
                            }

                            if (bool.Parse(config["Listen:Https:Enable"]))
                            {
                                options.Listen(IPAddress.Any, int.Parse(config["Listen:Https:Port"]), option =>
                                {
                                    option.UseHttps(config["Listen:Https:Cert"], config["Listen:Https:Password"]);
                                    option.UseConnectionLogging();
                                });
                            }
                        })
                        .ConfigureLogging(options =>
                        {
                            options.ClearProviders();
                            options.SetMinimumLevel(LogLevel.Trace);
                        })
                        .UseNLog();
                });
    }
}
