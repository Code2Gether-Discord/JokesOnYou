using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;

namespace JokesOnYou.Web.Api.Services
{
    public class JokesService : IJokesService
    {
        private readonly IJokesRepository _jokesRepo;

        public JokesService(IJokesRepository jokesRepo)
        {
            _jokesRepo = jokesRepo;
        }

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _jokesRepo.GetAllJokeDtosAsync();

            return jokeDtos;
        }

        public Task<JokeReplyDto> GetJokeDtoAsync(int id)
        {
            return _jokesRepo.GetJokeDtoAsync(id);
        }
    }
}
