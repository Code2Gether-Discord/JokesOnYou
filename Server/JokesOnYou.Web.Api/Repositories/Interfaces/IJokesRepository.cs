using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        public Task<IEnumerable<Joke>> GetAllJokesAsync();
        void DeleteJoke(Joke joke);
        Task<Joke> GetJokeByIdAsync(int id);
        Task CreateJokeAsync(Joke joke);
        Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}