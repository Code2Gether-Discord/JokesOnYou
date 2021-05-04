using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();

        public Task UpdateJoke(JokeUpdateDto jokeUpdateDto);

        public Task<JokeReplyDto> GetJokeReplyById(int id);
        Task<JokeReplyDto> CreateJokeAsync(JokeCreateDto jokeCreateDto);
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}
