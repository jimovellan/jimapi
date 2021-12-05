using jim.common.Exceptions;
using jim.models.Entity.Msgs;
using jim.models.Msgs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace jim.test
{
    [TestClass]
    public class MsgTest
    {
        [TestMethod]
        public void Msg_WhenDataInCreateToUserIsCorrect_Then_Returns_ValidOBject()
        {
            var toUser = Guid.NewGuid().ToString();
            var msg = "message body";
            var sut = Msg.Create(msg, toUser);
            Assert.IsTrue(sut.Body.Equals(msg));
            Assert.IsTrue(sut.To.Equals(toUser));
            Assert.IsTrue(sut.Type == MsgType.ToUser);
        }


        [TestMethod]
        public void Msg_WhenDataInCreateToBroadcastIsCorrect_Then_Returns_ValidOBject()
        {
            var msg = "message body";
            var sut = Msg.Create(msg);
            Assert.IsTrue(sut.Body.Equals(msg));
            Assert.IsTrue(sut.Type == MsgType.BroadCast);
        }

        [TestMethod]
        public void Msg_WhenDataInCreateToBroadcastNoValid_Then_Returns_ValidationException()
        {
            var msg = "message body";
            Assert.ThrowsException<ValidationCustomException>(()=>Msg.Create(string.Empty));
            Assert.ThrowsException<ValidationCustomException>(() => Msg.Create(string.Empty,string.Empty));
            Assert.ThrowsException<ValidationCustomException>(() => Msg.Create(msg,string.Empty));
        }
    }
}
