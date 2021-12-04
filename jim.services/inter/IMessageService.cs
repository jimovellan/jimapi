using jim.models.Entity.Msgs;
using System.Threading.Tasks;

namespace jim.api.Services.inter
{
    public interface IMessageService
    {
        /// <summary>
        /// Send a message to determinate User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task AddMessageAsync(Msg msg);

        
    }
}
