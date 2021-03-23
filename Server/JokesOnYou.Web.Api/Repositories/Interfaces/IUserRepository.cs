using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task DeleteUserAsync(int id);
        void UpdateUser(User user);
    }
}
