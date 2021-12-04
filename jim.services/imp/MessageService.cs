using AutoMapper;
using jim.api.services.inter;
using jim.api.Services.inter;
using jim.common.Exceptions;
using jim.models.Dto.Msg;
using jim.models.Entity.Msgs;
using jim.models.Entity.Users;
using jim.services.inter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jim.services.imp
{
    public class MessageService : IMessageService
    {
        private IUserService _userService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public MessageService(IUserService userService, 
                              INotificationService notificationService,
                              IMapper mapper)
        {
            _userService = userService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task AddMessageAsync(Msg msg)
        {

            switch (msg.Type)
            {
                case models.Msgs.MsgType.ToUser:
                    SendMessageToUser(msg);
                    break;
                case models.Msgs.MsgType.BroadCast:
                    SendMessageBroadCast(msg);
                    break;
                
            }
        }

        private void SendMessageToUser(Msg msg)
        {
            var user = _userService.GetUserAsync(msg.To).Result;
            
           if(user == null)
           {
             throw new CustomNotFoundException(typeof(User), msg.To);
           }

            //persist if required in future

            _notificationService.SendMessageToUserAsync(_mapper.Map<MsgDto>(msg));


        }

        private void SendMessageBroadCast(Msg msg)
        {
            //persist if required in future
            _notificationService.BroadCastMessageAsync(_mapper.Map<MsgDto>(msg));
        }
    }
}
