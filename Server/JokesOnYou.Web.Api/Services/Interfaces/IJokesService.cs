using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {      
        Task RemoveJokeAsync(int id);
        Task<JokeReplyDto> UpdateJoke(JokeUpdateDto jokeUpdateDto);
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
        Task<JokeReplyDto> CreateJokeAsync(JokeDto jokeDto, string userId);
        Task<IEnumerable<JokeReplyDto>> GetFilteredJokeDtosAsync(JokeFiltersDto filtersDto);
    }
}
