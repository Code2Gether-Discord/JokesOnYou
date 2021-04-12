using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
