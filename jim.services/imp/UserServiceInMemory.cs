using jim.api.services.inter;
using jim.models.Entity.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jim.services.imp
{
    /// <summary>
    /// Desarrollo esta parte pensando que posiblemente puedan cambiar los metodos de persistencia de los usuarios
    /// Este servicio los guarda en memoria
    /// </summary>
    public class UserServiceInMemory : IUserService
    {
        private static IList<User> _users = new List<User>();

        public UserServiceInMemory()
        {

        }
        public UserServiceInMemory(IList<User> users)
        {
            _users = users;
        }
        

        public async Task AddUserToConectionAsync(User user)
        {
            _users.Add(user);
        }
        

        public async Task<IList<User>> GetAllUsersAsync()
        {
            return _users;
        }

        public async Task<User> GetUserAsync(string userId)
        {
            return _users.FirstOrDefault(wh => wh.Id == userId);

        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await GetUserAsync(userId);
            _users.Remove(user);
        }


    }
}
