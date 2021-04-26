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
        public Task<Joke> GetJokeToUpdate(JokeUpdateDTO jokeUpdateDTO);
        public Task<JokeReplyDto> GetJokeReplyById(int id);
        public Task<Joke> GetJokeById(int id); 
        public Task Save(); 
    }
}
