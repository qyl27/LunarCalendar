using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;

namespace LunarCalendar
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private ILogger Log { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log = LogManager.GetLogger(nameof(Startup));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Allow cors.
            services.AddCors(option =>
            {
                option.AddPolicy("AllowCors", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Record real IP.
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.All;
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(next =>
            {
                return async context =>
                {
                    context.Response.OnStarting(() =>
                    {
                        context.Response.Headers["Server"] = "LunarCalendar";
                        context.Response.Headers.Add("Author", "Amemiya Sigure");
                        return Task.CompletedTask;
                    });

                    // Log requests.
                    Log.Info($"Got a {context.Request.Protocol} {context.Request.Method} request from " +
                        $"{context.Request.Host} to {context.Request.Path} with endpoint " +
                        $"{context.Connection.RemoteIpAddress.MapToIPv4()}:{context.Connection.RemotePort} and ID is " +
                        $"{context.Connection.Id}.");

                    await next(context);
                };
            });

            if (env.IsDevelopment())
            {
                Log.Debug("Hi there, welcome to potato world.");
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowCors");

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
