using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IJokesRepository
    {
        Task CreateJokeAsync(Joke joke);
        Task<IEnumerable<Joke>> GetAllJokesAsync();
        Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline);
        Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
        public Task<IEnumerable<Joke>> GetAllJokesAsync();
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        public Task<Joke> GetJokeToUpdate(JokeUpdateDto jokeUpdateDto);
        public Task<JokeReplyDto> GetJokeReplyById(int id);
        public Task<Joke> GetJokeById(int id); 
        public Task Save(); 
    }
}