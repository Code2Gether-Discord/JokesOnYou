using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ITagRepository
    {
        void Delete(Tag tag);
        Task<Tag> GetTagAsync(int id);
        Task<List<Tag>> GetTags(int[] ids);
        Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync();
        Task<TagReplyDto> GetTagDtoAsync(int id);
    }
}
