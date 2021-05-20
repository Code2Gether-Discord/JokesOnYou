using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ITagService
    {
        Task DeleteTagAsync(Tag tag);
        Task<Tag> GetTagAsync(int id);
        Task<TagReplyDto> CreateTagAsync(TagCreateDto tagCreateDto);
        Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync();
    }
}
