using JokesOnYou.Web.Api.Helpers;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Request.Query;
using JokesOnYou.Web.Api.Models.Response;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(UserRegisterDto userRegisterDTO);
        Task DeleteUserAsync(User user);
        Task<UserReplyDto> GetUserReplyAsync(string id);
        Task<PaginatedList<UserReplyDto>> GetUsersReplyDtoAsync(UserParameters parameters);
        Task<User> GetUserByUsernameAsync(string username);


    }
}