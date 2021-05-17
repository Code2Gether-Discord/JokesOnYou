using JokesOnYou.Web.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ITagService
    {
        Task DeleteTag(int tagId);
        Task DeleteMultipleTag(int[] tagIds);
        Task<TagReplyDto> GetTag(int id);
        Task<List<TagReplyDto>> GetTags(int[] ids);
        Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync();
    }
}
