using AutoMapper;
using AutoMapper.QueryableExtensions;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Helpers;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TagRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TagReplyDto>> GetAllTagDtosAsync(TagFilterDto tagFilterDto)
        {
            var query = _context.Tags.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(tagFilterDto.OwnerId))
            {
                query = query.Where(t => t.OwnerId == tagFilterDto.OwnerId);
            }

            query = query.Where(t => t.Likes >= tagFilterDto.MinimumLikes && t.Likes <= tagFilterDto.MaximumLikes);

            if (tagFilterDto.MinimumDate != DateTime.MinValue || tagFilterDto.MaximumDate != DateTime.MaxValue)
            {
                query = query.Where(t => t.Created >= tagFilterDto.MinimumDate && t.Created <= tagFilterDto.MaximumDate.AddDays(1));
            }
            if (string.IsNullOrEmpty(tagFilterDto.SearchText) == false || string.IsNullOrWhiteSpace(tagFilterDto.SearchText) == false)
            {
                query = query.Where(x => x.Name.Contains(tagFilterDto.SearchText));
            }

            var result = await PaginatedList<TagReplyDto>.ToPaginatedListAsync(query.ProjectTo<TagReplyDto>(_mapper.ConfigurationProvider), tagFilterDto.PageNumber, tagFilterDto.PageSize);

            return result;
        }

        public async Task<TagReplyDto> GetTagDtoAsync(int id) =>
            await _context.Tags.ProjectTo<TagReplyDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(t => t.Id == id);
        public async Task<List<Tag>> GetTags(int[] ids) =>
            await _context.Tags.Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<IEnumerable<TagReplyDto>> GetTagDtosByJokeIdAsync(int jokeId) =>
         await (from tags in _context.Tags
                join userJokeTags in _context.UserJokeTags
                on tags.Id equals userJokeTags.TagId
                where userJokeTags.JokeId == jokeId
                select new TagReplyDto
                {
                    Id = tags.Id,
                    Name = tags.Name,
                    Created = tags.Created,
                    OwnerId = tags.OwnerId,
                    Likes = userJokeTags.Likes
                }).ToListAsync();

        /// <summary>
        /// Find Tag by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Tag> GetTagAsync(int id) => await _context.Tags.FindAsync(id);

        /// <summary>
        /// Deletes given <paramref name="tag"/>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public void Delete(Tag tag) => _context.Tags.Remove(tag);

        public async Task CreateTagAsync(Tag tag) => await _context.Tags.AddAsync(tag);
        public async Task<Tag> GetTagByNameAsync(string tagName) => await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
    }
}
