using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        Task<IEnumerable<Joke>> GetAllJokesAsync();
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        void DeleteJoke(Joke joke);
        Task<Joke> GetJokeByIdAsync(int id);
        Task CreateJokeAsync(Joke joke);
        Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}