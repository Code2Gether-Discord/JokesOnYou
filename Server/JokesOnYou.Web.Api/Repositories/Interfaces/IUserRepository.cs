using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(UserRegisterDTO userRegisterDTO);
        Task DeleteUserAsync(User user);
        Task<UserReplyDTO> GetUserReplyAsync(string id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task UpdateUser(User user);
    }
}