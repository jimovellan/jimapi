
using jim.models.Dto.Msg;
using Jim.client.Common;
using Jim.client.Config;
using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace Jim.Client
{
    class Program
    {
        /// <summary>
        /// BEFORE,  CONFIGURE CONNECTION URL TO SERVER TO CONNECT
        /// FILE: appsettings.json
        /// KEY: { 
        ///         endpoints : {
        ///                         ServerHub : "URL HERE"
        ///                     }
        ///      }
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var userName = RequestUserName();
                var connection = Connect(userName);
                Hookevents(connection);
            }
            catch (Exception ex)
            {
                MessageHandler.WriteMessageError(ex.Message);

            }

            StopConsole();
        }

        /// <summary>
        /// subscribe to connection events
        /// </summary>
        /// <param name="connection"></param>
        public static void Hookevents(HubConnection connection)
        {


            connection.On("ReceiveMessage", (MsgDto msg) =>
            {
                MessageHandler.WriteMessage(msg);
            });

            connection.On("ConnectedToChannel", (MsgDto msg) =>
            {
                MessageHandler.WriteMessage(msg);
            });

            connection.On("Error", (MsgDto msg) =>
            {
                MessageHandler.WriteMessageError(msg);
            });
        }
        /// <summary>
        /// Open connection to socket
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private static HubConnection Connect(string userName)
        {
            var connection = new HubConnectionBuilder().WithUrl(Settings.UrlHub).Build();
            connection.StartAsync().Wait();
            connection.SendAsync("AddToChannel", userName).Wait();
            return connection;
        }
        /// <summary>
        /// Request the user name to subscribe to General Channel
        /// </summary>
        /// <returns></returns>
        private static string RequestUserName()
        {
            Console.WriteLine("Escribe tu nombre de usuario para comenzar");
            return Console.ReadLine();
        }
        /// <summary>
        /// Stop the program execution, waiting to push a key
        /// </summary>
        private static void StopConsole()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("--Pulsa cualquier tecla para finalizar para finalizar---");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
        }

    }





}
