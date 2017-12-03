using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET.Infrastructure.Middlewares;
using ASP.NET.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                using (var memoryStream = new MemoryStream())
                {
                    var bodyStream = context.Response.Body;
                    context.Response.Body = memoryStream;

                    await next();

                    stopwatch.Stop();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using (var streamReader = new StreamReader(memoryStream))
                    {
                        var responseBody = await streamReader.ReadToEndAsync();
                        responseBody = responseBody.Replace("</footer>", $"<p>Время обработки запроса: {stopwatch.Elapsed.TotalSeconds} секунд</p></footer>");

                        using (var streamWriter = new StreamWriter(bodyStream))
                        {
                            streamWriter.Write(responseBody);
                        }
                    }
                }
            });
            app.UseMiddleware<ConsoleLoggerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
