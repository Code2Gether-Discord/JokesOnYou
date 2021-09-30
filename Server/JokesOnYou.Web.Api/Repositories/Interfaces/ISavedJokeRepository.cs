using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ISavedJokeRepository
    {
        Task AddSavedJoke(SavedJoke savedJoke);
        Task<IEnumerable<SavedJokeReplyDto>> GetSavedJokesByUserId(string id);
    }
}