using AutoMapper;
using jim.api.services.inter;
using jim.services.imp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jim.test.Services
{
    [TestClass]
    public class UserServiceTest
    {

        private readonly IUserService _sut;

        public UserServiceTest()
        {
            _sut = new UserServiceInMemory(Mock.UsersMock.ListUserMock);
        }
        [TestMethod]
        public async Task When_ISearchAuserThatExist_Then_ReturnUser()
        {
            var user = await _sut.GetUserAsync(Mock.UsersMock.userId1);

            Assert.AreEqual(user, Mock.UsersMock.UserMock1);

        }
        [TestMethod]
        public async Task When_ISearchAuserThatNotExist_Then_Nullr()
        {
            var user = await _sut.GetUserAsync("xkjdksflkjdsf");

            Assert.IsNull(user);

        }

        [TestMethod]
        public async Task When_DeleteAuserThatNotExist_Then_NotFound()
        {
            await _sut.DeleteUserAsync(Mock.UsersMock.userId1);

            var user  = await _sut.GetUserAsync(Mock.UsersMock.userId1);

            Assert.IsNull(user);

        }
        [TestMethod]
        public async Task When_GetllUsers_Return_ListOf6()
        {
            var count = Mock.UsersMock.ListUserMock.Count;

            var users = await _sut.GetAllUsersAsync();

            Assert.IsTrue(count == users.Count);

        }


    }
}
