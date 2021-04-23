using JokesOnYou.Web.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {
        public Task<JokeReplyDto> CreateJokeAsync(JokeCreateDto jokeCreateDto);
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
    }
}
