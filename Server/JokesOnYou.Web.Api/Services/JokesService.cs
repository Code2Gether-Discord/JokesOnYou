using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
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
        public async Task<JokeReplyDto> CreateJokeAsync(JokeCreateDto jokeCreateDto)
        {
            jokeCreateDto.Premise = jokeCreateDto.Premise.Trim();
            jokeCreateDto.Punchline = jokeCreateDto.Punchline.Trim();

            var isDuplicate = await IsJokeDuplicate(jokeCreateDto);
            if (isDuplicate)
            {
                throw new AppException("Joke Already exists.");
            }

            var user = await _userRepository.GetUserAsync(jokeCreateDto.UserId);
            var joke = _mapper.Map<Joke>(jokeCreateDto);
            joke.Author = user;

            await _jokesRepo.CreateJokeAsync(joke);
            var saved = await _unitOfWork.SaveAsync();
            if (!saved)
            {
                throw new AppException("Error with saving the Joke.");
            }

            var jokeReplyDto = _mapper.Map<JokeReplyDto>(joke);

            return jokeReplyDto;
        }

        private async Task<bool> IsJokeDuplicate(JokeCreateDto jokeCreateDto)
        {
            var jokes = await _jokesRepo.GetJokesByPremiseAsync(jokeCreateDto.Premise);

            if (jokes.Any())
            {
                var lowerPunchline = jokeCreateDto.Punchline.ToLower();
                foreach (var foundJoke in jokes)
                {
                    if (foundJoke.Punchline.ToLower() == lowerPunchline)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _jokesRepo.GetAllJokeDtosAsync();

            return jokeDtos;
        }
    }
}
