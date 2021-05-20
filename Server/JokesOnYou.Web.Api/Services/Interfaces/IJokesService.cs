using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {      
        Task RemoveJokeAsync(int id);
        Task<JokeReplyDto> UpdateJoke(JokeUpdateDto jokeUpdateDto);
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeWithAuthorReplyDto> GetJokeDtoAsync(int id);
        Task<JokeReplyDto> CreateJokeAsync(JokeCreateDto jokeCreateDto);
    }
}
