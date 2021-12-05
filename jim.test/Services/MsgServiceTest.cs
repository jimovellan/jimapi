using AutoMapper;
using jim.api.services.inter;
using jim.api.Services.inter;
using jim.common.Exceptions;
using jim.models.Dto.Msg;
using jim.models.Entity.Msgs;
using jim.models.Entity.Users;
using jim.services.imp;
using jim.services.inter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace jim.test.Services
{
    [TestClass]
    public class MsgServiceTest
    {

        private readonly IMessageService _sut;
        private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<INotificationService> _notificationService = new Mock<INotificationService>();
        public MsgServiceTest()
        {
            _sut = new MessageService(_userServiceMock.Object, _notificationService.Object, _mapper.Object);
        }


        [TestMethod]
        public async Task WhenSendAMessageToNotDisconectedUser_SouldReturn_CustomNotFoundException()
        {

            var msgMock = Mock.MessageMock.MsgToUserMock1;

            await Assert.ThrowsExceptionAsync<CustomNotFoundException>(() => _sut.AddMessageAsync(msgMock));


        }

        [TestMethod]
        public async Task WhenSendAMessageTo_A_User_Should_NotificateMsg_OneTime()
        {
            var message = "message";
            var msgMock = Mock.MessageMock.MsgToUserMock1;
            var userMock = Mock.UsersMock.UserMock1;

            _userServiceMock.Setup(s => s.GetUserAsync(msgMock.Id)).ReturnsAsync(userMock);

            await _sut.AddMessageAsync(msgMock);

            _notificationService.Verify(x => x.SendMessageToUserAsync(It.IsAny<MsgDto>()), Times.Once);


        }


        [TestMethod]
        public async Task WhenSendAMessageTo_BroadCast_Should_NotificateAllUsers_OneTime()
        {
            var message = "message";
            
            var msg = Msg.Create(message);
           
            await _sut.AddMessageAsync(msg);

            _notificationService.Verify(x => x.BroadCastMessageAsync(It.IsAny<MsgDto>()), Times.Once);


        }
    }
}
