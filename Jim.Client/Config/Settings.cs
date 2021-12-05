
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Jim.client.Config
{
    public static class Settings
    {
        private static IConfiguration Config
        {
            get

            {

                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
                var config = builder.Build();
                return config;

            }
        }


        public static string UrlHub { get { return Config["endpoints:ServerHub"]; } }

    }
}
