using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ILikeForTagsService
    {
        Task<TagReplyDto> ToggleLikeForTag(UserJokeTag userJokeTag, string userId);
    }
}
