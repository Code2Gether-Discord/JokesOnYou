using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(UserRegisterDto userRegisterDTO);
        Task DeleteUserAsync(User user);
        Task<UserReplyDto> GetUserReplyAsync(string id);
        Task<IEnumerable<UserReplyDto>> GetUsersReplyDtoAsync();
        Task<User> GetUserByUsernameAsync(string username);


    }
}