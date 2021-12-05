using jim.models.Dto.Msg;
using System;

namespace Jim.client.Common
{
    public static class MessageHandler
    {

        public static void WriteMessageError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
        }

        public static void WriteMessage(MsgDto msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteMessageGeneral(msg);
        }

        public static void WriteMessageError(MsgDto msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteMessageGeneral(msg);
        }

        private static void WriteMessageGeneral(MsgDto msg)
        {
            Console.WriteLine("=================== Message Received ===================");
            Console.WriteLine(String.Format("Date: {0}", DateTime.Now.ToString()));
            Console.WriteLine(String.Format("Id: {0}", msg.Id));
            Console.WriteLine(String.Format("Msg: {0}", msg.Body));
            Console.WriteLine("========================================================");
        }
    }
}
