using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepo;

        public TagService(ITagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }
        /// <summary>
        /// Deletes given <paramref name="tag"/>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTag(TagCreateDto tag)
        {
            return await _tagRepo.Delete(tag);
        }

        /// <summary>
        /// Deletes given <paramref name="tagId"/>
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTag(int tagId)
        {
            return await _tagRepo.Delete(tagId);
        }


        /// <summary>
        /// Deletes all given <paramref name="tags"/>
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<bool> DeleteMultipleTag(List<TagCreateDto> tags)
        {
            return await _tagRepo.DeleteRange(tags);
        }


        /// <summary>
        /// Deletes all given <paramref name="tagIds"/>
        /// </summary>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        public async Task<bool> DeleteMultipleTag(int[] tagIds)
        {
            return await _tagRepo.DeleteRange(tagIds);
        }
    }
}
