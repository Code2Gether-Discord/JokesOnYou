using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Registered,Admin")]
    public class LikeForTagsController : ControllerBase
    {
        private readonly ILikeForTagsService _likeForTagsService;
        private readonly IUserJokeTagRepository _userJokeTagRepository;

        public LikeForTagsController(ILikeForTagsService likeForTagsService, IUserJokeTagRepository userJokeTagRepository)
        {
            _likeForTagsService = likeForTagsService;
            _userJokeTagRepository = userJokeTagRepository;
        }

        [HttpPost]
        public async Task<ActionResult> ToggleLikeUserJokeTag(int jokeId, int tagId)
        {
            TagReplyDto tagReplyDto = null;
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            UserJokeTag userJokeTag = await _userJokeTagRepository.GetUserJokeTagAsync(jokeId, tagId);
            int currentLikes = userJokeTag.Likes; // to be used to determine whether user is liking or unliking

            if (userJokeTag != null) // only perform this action if User JokeTag exist
            {
                tagReplyDto = await _likeForTagsService.ToggleLikeForTag(userJokeTag, userId);
            }

            if(tagReplyDto.Likes > currentLikes)
            {
                return Ok(); // like
            }
            else
            {
                return NoContent(); // unlike
            }
         
        }


    }
}
