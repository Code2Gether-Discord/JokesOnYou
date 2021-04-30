using AutoMapper;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
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
        public TagRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Find Tag by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Tag> Find(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<List<Tag>> GetTags(int[] ids)
        {
            return await _context.Tags.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
       
        /// <summary>
        /// Deletes given <paramref name="tagId"/>
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task Delete(int tagId)
        {
            var entity = await this.Find(tagId);
            _context.Remove(entity);
        }


        /// <summary>
        /// Deletes all given <paramref name="tags"/>
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task DeleteRange(int[] tags)
        {
            var entities = await _context.Tags.Where(x=>tags.Contains(x.Id)).ToListAsync();
            _context.RemoveRange(entities);
        }
    }
}
