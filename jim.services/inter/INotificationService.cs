using jim.models.Dto.Msg;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jim.services.inter
{
    public interface INotificationService
    {
        public Task SendMessageToUserAsync(MsgDto msg);
        public Task BroadCastMessageAsync(MsgDto msg);

    }
}
