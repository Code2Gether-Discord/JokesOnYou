using JokesOnYou.Web.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();

        public Task UpdateJoke(JokeUpdateDto jokeUpdateDto);

        public Task<JokeReplyDto> GetJokeReplyById(int id);
    }
}
