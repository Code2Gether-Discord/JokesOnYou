using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
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
        private readonly IMapper _mapper;

        public JokesService(IJokesRepository jokesRepo, IMapper mapper)
        {
            _jokesRepo = jokesRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _jokesRepo.GetAllJokeDtosAsync();

            return jokeDtos;
        }

        public async Task UpdateJoke(JokeUpdateDto jokeUpdateDto)
        {
            // get the joke we need to update
            // set fields with jokeUpdateDto
            var jokeToUpdate = await _jokesRepo.GetJokeToUpdate(jokeUpdateDto);

            if (jokeToUpdate == null)
            {
                throw new NotImplementedException("can't find joke to update");
            }

            jokeToUpdate.Premise = jokeUpdateDto.Premise;
            jokeToUpdate.Punchline = jokeUpdateDto.Punchline;

            await _jokesRepo.Save(); 
        }

        public async Task<JokeReplyDto> GetJokeReplyById(int id)
        {
            var jokeDtos = await _jokesRepo.GetJokeReplyById(id);

            return jokeDtos;
        }
    }
}
