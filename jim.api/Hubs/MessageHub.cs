
using jim.api.services.inter;
using jim.models.Dto.Msg;
using jim.models.Entity.Users;
using jim.services.inter;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jim.api.Hubs
{
    public class MessageHub : Hub,INotificationService
    {
        private readonly IUserService _userService;
        private readonly IHubContext<MessageHub> _context;
        private readonly ILogger<MessageHub> _log;


        public MessageHub(IUserService userService,
                         IHubContext<MessageHub> context,
                         ILogger<MessageHub> log)
        {
            _userService = userService;
            _context = context;
            _log = log;
        }



        /// <summary>
        /// Catch event when a user disconect from Hub
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await QuitFromUsers(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

       
        /// <summary>
        /// Add a user to general channel, asign a username 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task AddToChannel(string name)
        {
            try
            {
                _log.LogTrace("Añadiento user {0} a canal {1}", name, Config.Hub.Messages.GROUP_BROADCAST);
                var msgBody = String.Format("Connected to Channel {0} : UserName : {1}", Config.Hub.Messages.GROUP_BROADCAST, name);
                var user = User.Create(name, Context.ConnectionId);
                await _userService.AddUserToConectionAsync(user);
                await _context.Groups.AddToGroupAsync(user.Id, Config.Hub.Messages.GROUP_BROADCAST);
                await SendMessageToUserAsync(new MsgDto() { Body = msgBody, To = user.Id, Type = models.Msgs.MsgType.ToUser });
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }
           
            
        }
        private async Task QuitFromUsers(string userId)
        {
           
            try
            {
                _log.LogTrace("Saliendo user {0} a canal {1}", userId, Config.Hub.Messages.GROUP_BROADCAST);
                await _userService.QuitUserToHubAsync(userId);
                await _context.Groups.RemoveFromGroupAsync(Context.ConnectionId, Config.Hub.Messages.GROUP_BROADCAST);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }
           
        }
        public async Task BroadCastMessageAsync(MsgDto msg)
        {
           
            try
            {
                _log.LogTrace("Enviando mensaje {0} a todos los usuarios del canal {1}", msg.Id, Config.Hub.Messages.GROUP_BROADCAST);
                await _context.Clients.All.SendAsync(Config.Hub.Messages.RECEIVE_MESSAGES_BY_CLIENT, msg);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }
        }
        public async Task SendMessageToUserAsync(MsgDto msg)
        {
            try
            {
                
                _log.LogTrace("Enviando mensaje {0} al usuario {1}", msg.Id, msg.To);
                await _context.Clients.Client(msg.To).SendAsync(Config.Hub.Messages.RECEIVE_MESSAGES_BY_CLIENT, msg);
            }catch(Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }

        }

       
    }
}
