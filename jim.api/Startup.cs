using jim.models.Entity.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace jim.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object CustomResult { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Config.Services.Config(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            //control all exceptions not captured
            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                    async context =>
                    {
                        var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                        var message = jim.common.Errors.Common.GenericError();
                        var response = CustomResponse.Fail(message);
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(response));
                        var log = builder.ApplicationServices.GetService<ILogger>();
                        log.LogError(exception, message);

                    });
            });
           

            app.UseRouting();

            //Not Aply 
            //app.UseAuthorization();

            app.UseEndpoints(Config.EndPoints.Config);
        }
    }
}
