using jim.models.Entity.Msgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace jim.test.Mock
{
    public class MessageMock
    {
        public static string Msg1Body = "To user 1";
        public static Msg MsgToUserMock1 = Msg.Create(Msg1Body, UsersMock.userId1);

        public static string MsgBodyBroadCast1 = "BroadCast";
        public static Msg MsgToBroadcast1 = Msg.Create(Msg1Body);
    }
}
