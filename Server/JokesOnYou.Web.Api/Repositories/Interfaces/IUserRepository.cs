using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteUserAsync(User user);
        Task<User> GetUserAsync(string id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task DeleteUserAsync(int id);
    }
}