using jim.models.Entity.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jim.api.services.inter
{
    public interface IUserService
    {
        /// <summary>
        /// Get all conected users
        /// </summary>
        /// <returns>List of connedted users, empty list if no exits</returns>
        Task<IList<User>> GetAllUsersAsync();

        /// <summary>
        /// Get a user by Identifier 
        /// </summary>
        /// <returns>Returns finded user null if not found</returns>
        Task<User> GetUserAsync(string userId);

        /// <summary>
        /// Add a user to list conected users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUserToConectionAsync(User user);

        /// <summary>
        /// Remove a user from connected users
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task DeleteUserAsync(string userId);

    }
}
