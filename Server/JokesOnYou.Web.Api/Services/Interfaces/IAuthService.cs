using JokesOnYou.Web.Api.DTOs;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserReplyDTO> LoginAsync(UserLoginDTO userLoginDTO);
        Task RegisterAsync(UserRegisterDTO userRegisterDTO);
    }
}
