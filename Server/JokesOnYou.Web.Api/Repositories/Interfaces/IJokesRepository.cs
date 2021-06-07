using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        Task<IEnumerable<Joke>> GetAllJokesAsync();
        Task<IEnumerable<JokeDto>> GetAllJokeDtosAsync();
        void DeleteJoke(Joke joke);
        Task<Joke> GetJokeByIdAsync(int id);
        Task CreateJokeAsync(Joke joke);
        Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        Task<JokeDto> GetJokeDtoAsync(int id);
    }
}