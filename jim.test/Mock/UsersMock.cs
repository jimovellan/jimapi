using jim.models.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace jim.test.Mock
{
    public static class UsersMock
    {

        public static string userId1 = "11111111111";
        public static string userId2 = "11111111112";
        public static string userId3 = "11111111113";
        public static string userId4 = "11111111114";
        public static string userId5 = "11111111115";
        public static string userId6 = "11111111116";

        public static User UserMock1 = User.Create("Name1", userId1);
        public static User UserMock2 = User.Create("Name2", userId2);
        public static User UserMock3 = User.Create("Name3", userId3);
        public static User UserMock4 = User.Create("Name4", userId4);
        public static User UserMock5 = User.Create("Name4", userId5);
        public static User UserMock6 = User.Create("Name5", userId6);

        public static IList<User> ListUserMock = new List<User>() { UserMock1, UserMock2, UserMock3, UserMock4, UserMock5, UserMock6 };
    }
}
