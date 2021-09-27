using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
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
        private readonly IUnitOfWork _unitOfWork;

        public SavedJokeService(ISavedJokeRepository savedJokeRepo, IUnitOfWork unitOfWork)
        {
            _savedJokeRepo = savedJokeRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task AddSavedJoke(int jokeId, string userId)
        {
            await _savedJokeRepo.AddSavedJoke(new SavedJoke()
            {
                JokeId = jokeId,
                UserId = userId
            });
            var saved = await _unitOfWork.SaveAsync();
            if (!saved)
            {
                throw new AppException("Error with saving the SavedJoke.");
            }
        }

        public async Task<IEnumerable<SavedJokeReplyDto>> GetSavedJokesByUserId(string id)
        {
            return await _savedJokeRepo.GetSavedJokesByUserId(id);
        }
    }
}
