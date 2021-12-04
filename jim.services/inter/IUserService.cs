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
        /// <returns></returns>
        Task<IList<User>> GetAllUsersAsync();

        /// <summary>
        /// Get a user 
        /// </summary>
        /// <returns>NotFoundCustomException<T> if the user not foud</returns>
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
        Task QuitUserToHubAsync(string userId);

    }
}
