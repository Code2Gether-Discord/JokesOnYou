using AutoMapper;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using JokesOnYou.Web.Api.Models.Response;
using System.Threading.Tasks;
using System.Collections.Generic;
using JokesOnYou.Web.Api.Models.Interfaces;

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

        public async Task<JokeReplyDto> CreateJokeAsync(JokeDto jokeDto, string userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if (user == null)
            {
                throw new AppException($"No user with this id:\"{userId}\" found in the Database.");
            }

            Joke joke = await BuildJokeFromJokeDtoAndUserId(jokeDto, userId);

            await _jokesRepo.CreateJokeAsync(joke);

            var saved = await _unitOfWork.SaveAsync();
            if (!saved)
            {
                throw new AppException("Error with saving the Joke.");
            }

            var jokeReplyDto = _mapper.Map<JokeReplyDto>(joke);

            return jokeReplyDto;
        }

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _jokesRepo.GetAllJokeDtosAsync();

            foreach (var jokeDto in jokeDtos)
            {
                await AddAuthorToJoke(jokeDto);
            }

            return jokeDtos;
        }
        public async Task<IEnumerable<JokeReplyDto>> GetFilteredJokeDtosAsync(JokeFiltersDto filtersDto)
        {
            var filters = BuildFiltersList(filtersDto);

            var jokeDtos = await _jokesRepo.GetFilterdJokesAsync(filters);

            foreach (var jokeDto in jokeDtos)
            {
                await AddAuthorToJoke(jokeDto);
            }

            return jokeDtos;
        }

        private static List<IFilter> BuildFiltersList(JokeFiltersDto filtersDto)
        {
            var filters = new List<IFilter>();

            if (filtersDto.Author != null)          {filters.Add(filtersDto.Author); }
            if (filtersDto.Likes != null)           { filters.Add(filtersDto.Likes); }
            if (filtersDto.SearchInText != null)    { filters.Add(filtersDto.SearchInText); }
            if (filtersDto.Date != null)            { filters.Add(filtersDto.Date); }

            return filters;
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

        public async Task<JokeReplyDto> UpdateJoke(JokeUpdateDto jokeUpdateDto)
        {
            var jokeDto = _mapper.Map<JokeCreateDto>(jokeUpdateDto);
            await TrimJokeAndCheckForDuplicate(jokeDto);

            var jokeToUpdate = await _jokesRepo.GetJokeByIdAsync(jokeUpdateDto.Id);
            if (jokeToUpdate == null)
            {
                throw new KeyNotFoundException("can't find joke to update");
            }

            _mapper.Map(jokeUpdateDto,jokeToUpdate);
            await _unitOfWork.SaveAsync();

            var jokeReplyDto = _mapper.Map<JokeReplyDto>(jokeToUpdate);
            await AddAuthorToJoke(jokeReplyDto);
            return jokeReplyDto;
        }

        public async Task<JokeReplyDto> GetJokeDtoAsync(int id)
        {
            var jokeDto = await _jokesRepo.GetJokeDtoAsync(id);
            if (jokeDto == null)
            {
                throw new KeyNotFoundException("Cant find joke");
            }

            await AddAuthorToJoke(jokeDto);

            return jokeDto;
        }

        private async Task AddAuthorToJoke(JokeReplyDto jokeDto)
        {
            var user = await _userRepository.GetUserReplyAsync(jokeDto.Author.Id);
            jokeDto.Author.UserName = user.UserName;
        }

        private async Task<Joke> BuildJokeFromJokeDtoAndUserId(JokeDto jokeDto, string userId)
        {
            var jokeCreateDto = _mapper.Map<JokeCreateDto>(jokeDto);
            jokeCreateDto.UserId = userId;
            await TrimJokeAndCheckForDuplicate(jokeCreateDto);

            var joke = _mapper.Map<Joke>(jokeCreateDto);

            return joke;
        }

        private async Task TrimJokeAndCheckForDuplicate(JokeCreateDto jokeCreateDto)
        {
            TrimAndNormalizeJokeCreateDto(jokeCreateDto);

            if (await _jokesRepo.DoesJokeExist(jokeCreateDto.NormalizedPremise, jokeCreateDto.NormalizedPunchline))
            {
                throw new AppException("Joke Already exists.");
            }
        }

        private static void TrimAndNormalizeJokeCreateDto(JokeCreateDto jokeCreateDto)
        {
            jokeCreateDto.Premise = jokeCreateDto.Premise.Trim();
            jokeCreateDto.Punchline = jokeCreateDto.Punchline.Trim();
            jokeCreateDto.NormalizedPremise = jokeCreateDto.Premise.ToUpper();
            jokeCreateDto.NormalizedPunchline = jokeCreateDto.Punchline.ToUpper();
        }
    }
}
