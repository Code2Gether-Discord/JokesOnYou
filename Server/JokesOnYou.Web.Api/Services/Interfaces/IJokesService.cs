using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {      
        Task RemoveJokeAsync(int id);
        Task<JokeDto> UpdateJoke(JokeUpdateDto jokeUpdateDto);
        Task<IEnumerable<JokeDto>> GetAllJokeDtosAsync();
        Task<JokeDto> GetJokeDtoAsync(int id);
        Task<JokeDto> CreateJokeAsync(JokeCreateDto jokeCreateDto);
        Task<IEnumerable<JokeDto>> GetJokesByFilter(FilterDTO filterDTO);
    }
}
