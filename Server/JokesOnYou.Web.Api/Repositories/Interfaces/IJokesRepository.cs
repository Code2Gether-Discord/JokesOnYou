using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        public Task CreateJokeAsync(Joke joke);
        public Task<IEnumerable<Joke>> GetAllJokesAsync();
        public Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}