using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        Task CreateJokeAsync(Joke joke);
        Task<IEnumerable<Joke>> GetAllJokesAsync();
        Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}