using AutoMapper;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class LikeForTagsRepository : ILikeForTagsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LikeForTagsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteLikedTag(LikeForTag likedTag) => _context.LikeForTags.Remove(likedTag);

        public async Task AddLikedTag(LikeForTag likedTag) => await _context.LikeForTags.AddAsync(likedTag);

        public async Task<IEnumerable<LikeForTag>> GetLikedTagByUserId(string userId) =>
            await _context.LikeForTags.Where(x => x.UserId == userId).ToListAsync();

        public async Task<LikeForTag> GetLikedTag(string userId, int userJokeTagId) =>
            await _context.LikeForTags.FirstOrDefaultAsync(x => x.UserId == userId && x.UserJokeTagId == userJokeTagId);
    }
}
