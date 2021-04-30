using AutoMapper;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class TagRepository : UnitOfWork,ITagRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TagRepository(DataContext context,IMapper mapper):base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Deletes given <paramref name="tag"/>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<bool> Delete(TagCreateDto tag)
        {
            var entity = _mapper.Map<Tag>(tag);
            _context.Remove(entity);
            return await SaveAsync();
        }


        /// <summary>
        /// Deletes given <paramref name="tagId"/>
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int tagId)
        {
            var entity = _context.Tags.Find(tagId);
            _context.Remove(entity);
            return await SaveAsync();
        }


        /// <summary>
        /// Deletes all given <paramref name="tags"/>
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRange(List<TagCreateDto> tags)
        {
            var entity = _mapper.Map<List<Tag>>(tags);
            _context.RemoveRange(entity);
            return await SaveAsync();
        }


        /// <summary>
        /// Deletes all given <paramref name="tags"/>
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRange(int[] tags)
        {
            var entities = _context.Tags.Where(x=>tags.Contains(x.Id)).ToList();
            _context.RemoveRange(entities);
            return await SaveAsync();
        }
    }
}
