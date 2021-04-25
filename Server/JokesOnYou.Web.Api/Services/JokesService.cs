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

        public async Task RemoveJokeAsync(int id)
        {
            _jokesRepo.DeleteJoke(
                await _jokesRepo.GetJokeByIdAsync(id)
                );
        }
    }
}
