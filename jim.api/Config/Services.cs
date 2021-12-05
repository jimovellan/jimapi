using jim.api.Hubs;
using jim.api.services.inter;
using jim.api.Services.inter;
using jim.services.imp;
using jim.services.inter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace jim.api.Config
{
    public static class Services
    {
        public static void Config(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSignalR();

            services.AddSingleton<IUserService, UserServiceInMemory>();

            services.AddTransient<IMessageService, MessageService>();

            services.AddSingleton<MessageHub>();

            services.AddTransient<INotificationService, MessageHub>();

            //Automate register all profiles files
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            AddSwagger(services);

        }


        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }
    }
}
