using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Helpers;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        void DeleteJoke(Joke joke);
        Task<Joke> GetJokeByIdAsync(int id);
        Task CreateJokeAsync(Joke joke);
        Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
        Task<PaginatedList<JokeReplyDto>> GetJokeDtosAsync(JokesFilterDto jokesFilter);
    }
}
