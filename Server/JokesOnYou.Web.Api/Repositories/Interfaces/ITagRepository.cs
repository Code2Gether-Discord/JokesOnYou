using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Helpers;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ITagRepository
    {
        void Delete(Tag tag);

        Task<Tag> GetTagAsync(int id);

        Task<List<Tag>> GetTags(int[] ids);

        Task<PaginatedList<TagReplyDto>>
        GetAllTagDtosAsync(
            TagFilterDto tagFilterDto
        );

        Task<TagReplyDto> GetTagDtoAsync(int id);

        Task CreateTagAsync(Tag tag);

        Task<IEnumerable<TagReplyDto>> GetTagDtosByJokeIdAsync(int jokeId);
    }
}
