using jim.common.Exceptions;
using jim.models.Entity.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace jim.test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_WhenDataIsNotCorrect_Then_Throw_Exception()
        {
            var guid = Guid.NewGuid().ToString();
            var name = "Name";
            Assert.ThrowsException<ValidationCustomException>(() => User.Create("", ""));
            Assert.ThrowsException<ValidationCustomException>(() => User.Create("", guid));
            Assert.IsNotNull(User.Create(name, guid));


        }
        [TestMethod]
        public void User_WhenDataInCreateIsCorrect_Then_Returns_ValidOBject()
        {
            var guid = Guid.NewGuid().ToString();
            var name = "Name";
            var sut = User.Create(name, guid);
            Assert.IsTrue(sut.Id.Equals(guid));
            Assert.IsTrue(sut.Name.Equals(name));
        }
    }
}
