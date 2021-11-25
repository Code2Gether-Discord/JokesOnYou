using AutoMapper;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class UserJokeTagRepository : IUserJokeTagRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserJokeTagRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteUserJokeTag(UserJokeTag userJokeTag) => _context.UserJokeTags.Remove(userJokeTag);
        public async Task CreateUserJokeTagAsync(UserJokeTag userJokeTag) => 
            await _context.UserJokeTags.AddAsync(userJokeTag);

        public async Task<UserJokeTag> GetUserJokeTagAsync(int id) => 
            await _context.UserJokeTags.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<UserJokeTag> GetUserJokeTagAsync(UserJokeTag userJokeTag) => 
             await _context.UserJokeTags.FirstOrDefaultAsync(x =>
                                                        x.JokeId == userJokeTag.JokeId && 
                                                        x.TagId == userJokeTag.TagId);
        public async Task<UserJokeTag> GetUserJokeTagAsync(int jokeId, int tagId) =>
             await _context.UserJokeTags.FirstOrDefaultAsync(x =>
                                                        x.JokeId == jokeId &&
                                                        x.TagId == tagId);
    }
}
