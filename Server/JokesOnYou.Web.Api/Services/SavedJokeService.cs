using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class SavedJokeService : ISavedJokeService
    {
        private readonly ISavedJokeRepository _savedJokeRepo;

        public SavedJokeService(ISavedJokeRepository savedJokeRepo)
        {
            _savedJokeRepo = savedJokeRepo;
        }

        public async Task AddSavedJoke(int jokeId, string userId)
        {
            await _savedJokeRepo.AddSavedJoke(new SavedJoke()
            {
                JokeId = jokeId,
                UserId = userId,
                SavedDate = System.DateTime.Now
            });
        }

        public async Task<IEnumerable<SavedJokeReplyDto>> GetSavedJokesByUserId(string id)
        {
            var yes = await _savedJokeRepo.GetSavedJokesByUserId(id);
            return yes;
        }

    }
}
