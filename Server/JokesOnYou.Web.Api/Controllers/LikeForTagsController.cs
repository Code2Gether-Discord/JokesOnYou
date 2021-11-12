using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
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

        public LikeForTagsController(ILikeForTagsService likeForTagsService)
        {
            _likeForTagsService = likeForTagsService;
        }
        
        [HttpPost]
        [Route("LikeTag")]
        public async Task<ActionResult<LikeForTagReplyDto>> LikeTagAsync(int tagId)
        {
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            var tagDto = await _likeForTagsService.LikeTagAsync(tagId, userId);
            return tagDto;
        }

        [HttpPost]
        [Route("UnlikeTag")]
        public async Task<ActionResult> UnlikeTagAsync(int tagId)
        {
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            await _likeForTagsService.UnlikeTagAsync(tagId, userId);
            return NoContent();
        }

    }
}
