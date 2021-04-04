using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> CreateUserAsync(UserRegisterDTO userRegisterDTO);
        Task DeleteUserAsync(string id);
        Task<UserReplyDTO> GetUserReplyAsync(string id);
        Task<IEnumerable<UserReplyDTO>> GetUsersAsync();
        Task UpdateUser(User user);
    }
}