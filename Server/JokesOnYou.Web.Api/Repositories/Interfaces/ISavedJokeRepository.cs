using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ISavedJokeRepository
    {
        void DeleteSavedJoke(SavedJoke savedjoke);
        Task<SavedJoke> GetSavedJoke(string id, int jokeId);
        Task AddSavedJoke(SavedJoke savedJoke);
        Task<IEnumerable<SavedJoke>> GetSavedJokesByUserId(string id);
    }
}