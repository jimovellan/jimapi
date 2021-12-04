
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Jim.client.Config
{
    public static class Settings
    {
        private static IConfiguration reader { get 
            
            {

                var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
              
                return builder.Build();

                

            } }


        public static string UrlHub { get { return "http://localhost:44861/Hub/Message"; } }//)}reader.AsEnumerable().FirstOrDefault(wh => wh.Key.Equals("endpoints:ServerHubs")).Value; } }

    }
}
