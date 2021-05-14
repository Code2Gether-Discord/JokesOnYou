using JokesOnYou.Web.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {
        Task<JokeReplyDto> CreateJokeAsync(JokeCreateDto jokeCreateDto);
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}
