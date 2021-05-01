using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationIdentity> _userManager;

        public TagController(ITagService tagService, ILogger<TagController> logger, UserManager<ApplicationIdentity> userManager)
        {
            _tagService = tagService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int tagId)
        {
            var tag = await _tagService.GetTag(tagId);
            string userId = _userManager.GetUserId(User);
            if (tag.UserReplyDTO.Id == userId || User.IsInRole("Admin"))
            {
                await _tagService.DeleteTag(tagId);
                return Ok($"{tagId}");
            }
            else
            {
                return Unauthorized();
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTags(int[] tagIds)
        {
            string userId = _userManager.GetUserId(User);
            var tags = await _tagService.GetTags(tagIds);
            //make sure the user id match with tags
            if (tags.Exists(x => x.UserReplyDTO.Id != userId) == false || User.IsInRole("Admin"))
            {
                await _tagService.DeleteMultipleTag(tagIds);
                string deletedIds = string.Join(",", tagIds);
                return Ok($"{deletedIds}");

            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
