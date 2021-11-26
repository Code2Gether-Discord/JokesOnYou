using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Helpers;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ITagService
    {
        Task DeleteTagAsync(Tag tag);

        Task<Tag> GetTagAsync(int id);

        Task<TagReplyDto>
        CreateTagAsync(
            TagCreateDto tagCreateDto, string userId
        );

        Task<PaginatedList<TagReplyDto>>
        GetAllTagDtosAsync(TagFilterDto tagFilterDto);

        Task<TagReplyDto> GetTagDtoAsync(int id);

        Task<IEnumerable<TagReplyDto>> GetTagDtosByJokeIdAsync(int jokeId);
    }
}
