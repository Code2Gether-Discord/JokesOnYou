using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Repositories;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class SavedJokeService : ISavedJokeService
    {
        private readonly ISavedJokeRepository _savedJokeRepo;
        private readonly IJokesRepository _jokeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SavedJokeService(ISavedJokeRepository savedJokeRepo, IUnitOfWork unitOfWork, IJokesRepository jokeRepository)
        {
            _savedJokeRepo = savedJokeRepo;
            _unitOfWork = unitOfWork;
            _jokeRepository = jokeRepository;
        }

        public async Task ToggleSavedJoke(int jokeId, string userId)
        {
            var joke = await _jokeRepository.GetJokeByIdAsync(jokeId);

            if (joke == null)
            {
                throw new AppException("Joke does not exist");
            }

            var savedjoke = await _savedJokeRepo.GetSavedJoke(userId, jokeId);

            if (savedjoke != null)
            {
                _savedJokeRepo.DeleteSavedJoke(savedjoke);
            }
            else
            {
                await _savedJokeRepo.AddSavedJoke(new SavedJoke()
                {
                    JokeId = jokeId,
                    UserId = userId
                });
            }
            
            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Error with saving the SavedJoke");
            }
        }

        public async IAsyncEnumerable<JokeReplyDto> GetSavedJokesByUserId(string id)
        {
            var SavedJokes = await _savedJokeRepo.GetSavedJokesByUserId(id);

            foreach (var item in SavedJokes){
                yield return await _jokeRepository.GetJokeDtoAsync(item.JokeId);
            }
        }
    }
}