using jim.models.Entity.Common;
using jim.models.Entity.Msgs;
using System.Threading.Tasks;

namespace jim.api.Services.inter
{
    public interface IMessageService
    {
        /// <summary>
        /// Add message to user or group
        /// </summary>
        /// <param name="msg">message to comunicate with other users</param>
        /// <returns></returns>
        Task<CustomResponse> AddMessageAsync(Msg msg);


    }
}
