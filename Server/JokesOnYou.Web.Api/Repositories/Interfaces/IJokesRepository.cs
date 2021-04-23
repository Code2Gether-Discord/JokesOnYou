using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        public Task CreateJokeAsync(Joke joke);
        public Task<List<Joke>> GetAllJokesAsync();
        public Task<IEnumerable<Joke>> GetJokesByPremiseAsync(string premise);
        public Task<List<JokeReplyDto>> GetAllJokeDtosAsync();
    }
}
