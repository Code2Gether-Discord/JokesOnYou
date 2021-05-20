using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(UserRegisterDTO userRegisterDTO);
        Task DeleteUserAsync(User user);
        Task<UserReplyDTO> GetUserReplyAsync(string id);
        Task<IEnumerable<UserReplyDTO>> GetUsersAsync();
        Task<User> GetUserByUsernameAsync(string username);


    }
}