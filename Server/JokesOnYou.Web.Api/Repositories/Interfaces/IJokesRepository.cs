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
        public Task<IEnumerable<Joke>> GetAllJokesAsync();
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        void DeleteJoke(Joke joke);
        Task<Joke> GetJokeByIdAsync(int id);
    }
}
