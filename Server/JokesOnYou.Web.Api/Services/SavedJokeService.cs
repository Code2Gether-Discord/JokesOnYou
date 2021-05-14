using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;

namespace JokesOnYou.Web.Api.Services
{
    public class SavedJokeService : ISavedJokeService
    {
        private readonly ISavedJokeRepository _savedJokeRepo;

        public SavedJokeService(ISavedJokeRepository savedJokeRepo)
        {
            _savedJokeRepo = savedJokeRepo;
        }
    }
}
