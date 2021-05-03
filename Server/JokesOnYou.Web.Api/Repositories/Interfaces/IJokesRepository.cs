using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        Task<IEnumerable<Joke>> GetAllJokesAsync();
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        void DeleteJoke(Joke joke);
        Task<JokeReplyDto> GetJokeByIdAsync(int id);
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}
