using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class TagService : UnitOfWork,ITagService
    {
        private readonly ITagRepository _tagRepo;
        private readonly IMapper _mapper;
        public TagService(DataContext context, ITagRepository tagRepo,IMapper mapper):base(context)
        {
            _tagRepo = tagRepo;
            _mapper = mapper;
        }

        public async Task<TagReplyDto> GetTag(int id)
        {
            var entity = await _tagRepo.Find(id);
            //TODO: DTO should be implemented
            return _mapper.Map<TagReplyDto>(entity);
        }

        public async Task<List<TagReplyDto>> GetTags(int[] ids)
        {
            var entity = await _tagRepo.GetTags(ids);
            //TODO: DTO should be implemented
            return _mapper.Map<List<TagReplyDto>>(entity);
        }

        /// <summary>
        /// Deletes given <paramref name="tagId"/>
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task DeleteTag(int tagId)
        {
            await _tagRepo.Delete(tagId);
            await SaveAsync();
        }


        /// <summary>
        /// Deletes all given <paramref name="tagIds"/>
        /// </summary>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        public async Task DeleteMultipleTag(int[] tagIds)
        {
            await _tagRepo.DeleteRange(tagIds);
            await SaveAsync();
        }

        public async Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync()
        {
            return await _tagRepo.GetAllTagDtosAsync();
        }
    }
}
