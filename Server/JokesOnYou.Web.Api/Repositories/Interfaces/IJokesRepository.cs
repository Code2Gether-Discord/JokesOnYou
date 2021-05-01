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
        public Task<IEnumerable<Joke>> GetAllJokesAsync();
        public Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}