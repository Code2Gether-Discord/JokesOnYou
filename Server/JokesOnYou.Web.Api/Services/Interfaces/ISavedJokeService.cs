using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ISavedJokeService
    {
        Task ToggleSavedJoke(int jokeId, string userId);
        Task<IEnumerable<JokeReplyDto>> GetSavedJokesByUserId(string id);
    }
}