using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ISavedJokeService
    {
        Task ToggleSavedJoke(int jokeId, string userId);
        IAsyncEnumerable<JokeReplyDto> GetSavedJokesByUserId(string id);
    }
}