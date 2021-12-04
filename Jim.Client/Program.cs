
using jim.models.Dto.Msg;
using jim.models.Msgs;
using Jim.client.Config;
using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace Jim.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Escribe tu nombre de usuario para comenzar");
            var user = Console.ReadLine();


            var connection = new HubConnectionBuilder().WithUrl(Settings.UrlHub).Build();
            connection.StartAsync().Wait();
            connection.SendAsync("AddToChannel", user).Wait();

            SetListeners(connection);

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Pulsa para finalizar");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
        }

        public static void SetListeners(HubConnection connection)
        {
            

            connection.On("ReceiveMessage", (MsgDto msg) => {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format("Date: {0}", DateTime.Now.ToString()));
                Console.WriteLine(String.Format("Id: {0}", msg.Id));
                Console.WriteLine("----------------------");
                Console.WriteLine(msg.Body);
                Console.WriteLine("----------------------");
                Console.WriteLine("----------------------");
            });

            connection.On("ConnectedToChannel", (MsgDto msg) => {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(String.Format("Date: {0}", DateTime.Now.ToString()));
                Console.WriteLine(String.Format("Id: {0}", msg.Id));
                Console.WriteLine("----------------------");
                Console.WriteLine(msg.Body);
                Console.WriteLine("----------------------");
                Console.WriteLine("----------------------");
            });

            connection.On("Error", (MsgDto msg) => {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("Date: {0}", DateTime.Now.ToString()));
                Console.WriteLine(String.Format("Id: {0}", msg.Id));
                Console.WriteLine("----------------------");
                Console.WriteLine(msg.Body);
                Console.WriteLine("----------------------");
                Console.WriteLine("----------------------");
            });
        }

    }

   


    
}
