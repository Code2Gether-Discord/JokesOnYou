using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Filters;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {      
        Task RemoveJokeAsync(int id);
        Task<JokeDto> UpdateJoke(JokeUpdateDto jokeUpdateDto);
        Task<IEnumerable<JokeDto>> GetAllJokeDtosAsync(JokesFilter jokesFilter);
        Task<JokeDto> GetJokeDtoAsync(int id);
        Task<JokeDto> CreateJokeAsync(JokeCreateDto jokeCreateDto);
    }
}
