using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
