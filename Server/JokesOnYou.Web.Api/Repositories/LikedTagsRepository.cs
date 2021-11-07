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
    public class LikedTagsRepository : ILikedTagsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LikedTagsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteLikedTag(LikedTags likedTags) => _context.LikedTags.Remove(likedTags);

        public async Task AddLikedTag(LikedTags likedTags) => await _context.LikedTags.AddAsync(likedTags);

        public async Task<IEnumerable<LikedTags>> GetLikedTagByUserId(string userId) =>
            await _context.LikedTags.Where(x => x.UserId == userId).ToListAsync();

        public async Task<LikedTags> GetLikedTag(string userId, int tagId) =>
            await _context.LikedTags.FirstOrDefaultAsync(x => x.UserId == userId && x.TagId == tagId);
    }
}
