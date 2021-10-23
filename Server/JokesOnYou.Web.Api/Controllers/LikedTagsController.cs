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
    [Authorize]
    public class LikedTagsController : ControllerBase
    {
        private readonly ILikedTagsService _likedTagsService;

        public LikedTagsController(ILikedTagsService likedTagsService)
        {
            _likedTagsService = likedTagsService;
        }

        [Authorize(Roles = "Registered,Admin")]
        [HttpPut]
        [Route("LikeTag")]
        public async Task<ActionResult<LikedTagsReplyDto>> LikeTagAsync(LikedTagsCreateDto likedTagsCreateDto)
        {
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            var tagDto = await _likedTagsService.LikeTagAsync(likedTagsCreateDto, userId);
            return tagDto;
        }

        [Authorize(Roles = "Registered,Admin")]
        [HttpPut]
        [Route("UnlikeTag")]
        public async Task<ActionResult> UnlikeTagAsync(UnlikedTagCreateDto unlikedTagCreateDto)
        {
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            await _likedTagsService.UnlikeTagAsync(unlikedTagCreateDto, userId);
            return NoContent();
        }

    }
}
