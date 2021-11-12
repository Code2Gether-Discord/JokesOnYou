using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ILikeForTagsService
    {
        Task<LikeForTagReplyDto> LikeTagAsync(int tagId, string userId);
        Task UnlikeTagAsync(int tagId, string userId);
    }
}
