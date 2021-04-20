using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IJokesService
    {
        public Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync();
        Task<JokeReplyDto> GetJokeDtoAsync(int id);
    }
}
