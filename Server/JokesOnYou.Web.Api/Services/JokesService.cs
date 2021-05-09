using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;

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

        public async Task<JokeReplyDto> CreateJokeAsync(JokeCreateDto jokeCreateDto)
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
                if(await _jokesRepo.GetJokeDtoAsync(joke.Id) == null)
                {
                    throw new AppException("Error with saving the Joke.");
                }
            }

            var jokeReplyDto = _mapper.Map<JokeReplyDto>(joke);

            return jokeReplyDto;
        }

        private static void TrimAndNormalizeJokeCreateDto(JokeCreateDto jokeCreateDto)
        {
            jokeCreateDto.Premise = jokeCreateDto.Premise.Trim();
            jokeCreateDto.Punchline = jokeCreateDto.Punchline.Trim();
            jokeCreateDto.NormalizedPremise = jokeCreateDto.Premise.ToUpper();
            jokeCreateDto.NormalizedPunchline = jokeCreateDto.Punchline.ToUpper();
        }

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _jokesRepo.GetAllJokeDtosAsync();

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

        public Task<JokeReplyDto> GetJokeDtoAsync(int id)
        {
            return _jokesRepo.GetJokeDtoAsync(id);
        }
    }
}
