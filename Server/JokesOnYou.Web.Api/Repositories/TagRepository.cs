using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;

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

        public async Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync() => await _context.Tags.ProjectTo<TagReplyDto>(_mapper.ConfigurationProvider).ToListAsync();
        public async Task<List<Tag>> GetTags(int[] ids) => await _context.Tags.Where(x => ids.Contains(x.Id)).ToListAsync();

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

        public async Task CreateTagAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag).AsTask();
        }
    }
}
