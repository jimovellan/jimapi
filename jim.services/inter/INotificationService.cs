using jim.models.Dto.Msg;
using System.Threading.Tasks;

namespace jim.services.inter
{
    public interface INotificationService
    {
        /// <summary>
        /// Notificate a message to user
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Task SendMessageToUserAsync(MsgDto msg);
        /// <summary>
        /// Notificate a message to group
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Task BroadCastMessageAsync(MsgDto msg);

    }
}
