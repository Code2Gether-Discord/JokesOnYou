using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        public Task<IEnumerable<Joke>> GetAllJokesAsync();
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        void DeleteJoke(Joke joke);
        Task<JokeReplyDto> GetJokeByIdAsync(int id);
    }
}
