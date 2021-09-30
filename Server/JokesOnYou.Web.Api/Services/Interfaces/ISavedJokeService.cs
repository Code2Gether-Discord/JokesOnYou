using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ISavedJokeService
    {
        Task AddSavedJoke(int jokeId, string userId);
        Task<IEnumerable<SavedJokeReplyDto>> GetSavedJokesByUserId(string id);
    }
}