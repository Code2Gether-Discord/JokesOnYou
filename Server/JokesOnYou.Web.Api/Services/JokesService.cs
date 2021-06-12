using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class JokesService : IJokesService
    {
        private readonly IJokesRepository _jokesRepo;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JokesService(IJokesRepository jokesRepo, IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _jokesRepo = jokesRepo;
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<JokeDto> CreateJokeAsync(JokeCreateDto jokeCreateDto)
        {
            TrimAndNormalizeJokeCreateDto(jokeCreateDto);

            if (await _jokesRepo.DoesJokeExist(jokeCreateDto.NormalizedPremise, jokeCreateDto.NormalizedPunchline))
            {
                throw new AppException("Joke Already exists.");
            }

            var user = await _userRepository.GetUserAsync(jokeCreateDto.UserId);
            if (user == null)
            {
                throw new AppException($"No user with this id:\"{jokeCreateDto.UserId}\" found in the Database.");
            }

            var joke = _mapper.Map<Joke>(jokeCreateDto);
            joke.AuthorId = user.Id;
            await _jokesRepo.CreateJokeAsync(joke);

            var saved = await _unitOfWork.SaveAsync();
            if (!saved)
            {
                throw new AppException("Error with saving the Joke.");
            }

            var jokeDto = _mapper.Map<JokeDto>(joke);
            jokeDto.Author.Id = user.Id;
            jokeDto.Author.UserName = user.UserName;

            return jokeDto;
        }

        private static void TrimAndNormalizeJokeCreateDto(JokeCreateDto jokeCreateDto)
        {
            jokeCreateDto.Premise = jokeCreateDto.Premise.Trim();
            jokeCreateDto.Punchline = jokeCreateDto.Punchline.Trim();
            jokeCreateDto.NormalizedPremise = jokeCreateDto.Premise.ToUpper();
            jokeCreateDto.NormalizedPunchline = jokeCreateDto.Punchline.ToUpper();
        }

        public async Task<IEnumerable<JokeDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _jokesRepo.GetAllJokeDtosAsync();

            foreach (var jokeDto in jokeDtos)
            {
                await AddAuthorToJoke(jokeDto);
            }

            return jokeDtos;
        }

        public async Task RemoveJokeAsync(int id)
        {
            var joke = await _jokesRepo.GetJokeByIdAsync(id);
            if (joke == null)
            {
                throw new KeyNotFoundException("Cant find joke");
            }

            _jokesRepo.DeleteJoke(joke);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Failed to remove joke");
            }
        }

        public async Task<JokeDto> UpdateJoke(JokeUpdateDto jokeUpdateDto)
        {
            var jokeToUpdate = await _jokesRepo.GetJokeByIdAsync(jokeUpdateDto.Id);
            if (jokeToUpdate == null)
            {
                throw new KeyNotFoundException("can't find joke to update");
            }

            _mapper.Map(jokeUpdateDto,jokeToUpdate);
            await _unitOfWork.SaveAsync();

            var jokeDto = _mapper.Map<JokeDto>(jokeToUpdate);
            await AddAuthorToJoke(jokeDto);
            return jokeDto;
        }

        public async Task<JokeDto> GetJokeDtoAsync(int id)
        {
            var jokeDto = await _jokesRepo.GetJokeDtoAsync(id);
            if (jokeDto == null)
            {
                throw new KeyNotFoundException("Cant find joke");
            }

            await AddAuthorToJoke(jokeDto);

            return jokeDto;
        }

        public async Task<IEnumerable<JokeDto>> GetJokesByFilter(FilterDTO filterDTO)
        {
            var allJokes = await _jokesRepo.GetAllJokeDtosAsync();

            var filteredJokes = allJokes;

            if (filterDTO.Likes > -1)
            {
                filteredJokes = filteredJokes.WhereIf(x => x.Likes == filterDTO.Likes, filterDTO.ComparisonModeLikes == ComparisonMode.Equals);
                filteredJokes = filteredJokes.WhereIf(x => x.Likes > filterDTO.Likes, filterDTO.ComparisonModeLikes == ComparisonMode.Greather);
                filteredJokes = filteredJokes.WhereIf(x => x.Likes >= filterDTO.Likes, filterDTO.ComparisonModeLikes == ComparisonMode.GreatherEquals);
                filteredJokes = filteredJokes.WhereIf(x => x.Likes < filterDTO.Likes, filterDTO.ComparisonModeLikes == ComparisonMode.Lower);
                filteredJokes = filteredJokes.WhereIf(x => x.Likes <= filterDTO.Likes, filterDTO.ComparisonModeLikes == ComparisonMode.LowerEquals);
                filteredJokes = filteredJokes.WhereIf(x => x.Likes != filterDTO.Likes, filterDTO.ComparisonModeLikes == ComparisonMode.NotEquals);
            }

            if (filterDTO.Dislikes > -1)
            {
                filteredJokes = filteredJokes.WhereIf(x => x.Dislikes == filterDTO.Dislikes, filterDTO.ComparisonModeDislikes == ComparisonMode.Equals);
                filteredJokes = filteredJokes.WhereIf(x => x.Dislikes > filterDTO.Dislikes, filterDTO.ComparisonModeDislikes == ComparisonMode.Greather);
                filteredJokes = filteredJokes.WhereIf(x => x.Dislikes >= filterDTO.Dislikes, filterDTO.ComparisonModeDislikes == ComparisonMode.GreatherEquals);
                filteredJokes = filteredJokes.WhereIf(x => x.Dislikes < filterDTO.Dislikes, filterDTO.ComparisonModeDislikes == ComparisonMode.Lower);
                filteredJokes = filteredJokes.WhereIf(x => x.Dislikes <= filterDTO.Dislikes, filterDTO.ComparisonModeDislikes == ComparisonMode.LowerEquals);
                filteredJokes = filteredJokes.WhereIf(x => x.Dislikes != filterDTO.Dislikes, filterDTO.ComparisonModeDislikes == ComparisonMode.NotEquals);
            }

            filteredJokes = filteredJokes.WhereIf(x => x.UploadDate == filterDTO.UploadDate, filterDTO.ComparisonModeUploadDate == ComparisonMode.Equals);
            filteredJokes = filteredJokes.WhereIf(x => x.UploadDate > filterDTO.UploadDate, filterDTO.ComparisonModeUploadDate == ComparisonMode.Greather);
            filteredJokes = filteredJokes.WhereIf(x => x.UploadDate >= filterDTO.UploadDate, filterDTO.ComparisonModeUploadDate == ComparisonMode.GreatherEquals);
            filteredJokes = filteredJokes.WhereIf(x => x.UploadDate < filterDTO.UploadDate, filterDTO.ComparisonModeUploadDate == ComparisonMode.Lower);
            filteredJokes = filteredJokes.WhereIf(x => x.UploadDate <= filterDTO.UploadDate, filterDTO.ComparisonModeUploadDate == ComparisonMode.LowerEquals);
            filteredJokes = filteredJokes.WhereIf(x => x.UploadDate != filterDTO.UploadDate, filterDTO.ComparisonModeUploadDate == ComparisonMode.NotEquals);

            filteredJokes = filteredJokes.WhereIf(x => x.Author == filterDTO.Author, filterDTO.Author != null);

            return filteredJokes;
        }

        private async Task AddAuthorToJoke(JokeDto jokeDto)
        {
            var user = await _userRepository.GetUserReplyAsync(jokeDto.Author.Id);
            jokeDto.Author.UserName = user.UserName;
        }
    }
}
