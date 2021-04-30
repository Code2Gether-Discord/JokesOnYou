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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationIdentity> _userManager;

        public TagController(ITagService tagService, ILogger logger, UserManager<ApplicationIdentity> userManager)
        {
            _tagService = tagService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTag(int? tagId)
        {
            if (tagId == null) return Problem("There is no declared tagId");
            try
            {
                var tag = await _tagService.GetTag(tagId.Value);
                string userId = _userManager.GetUserId(User);
                if (tag.UserReplyDTO.Id == userId || User.IsInRole("Admin"))
                {
                    await _tagService.DeleteTag(tagId.Value);
                    return Ok($"{tagId}");
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return Problem(ex.Message);
            }
            
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTags(int[] tagIds)
        {
            if (tagIds == null) return Problem("There is no declared tagIds");
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return Problem(ex.Message);
            }
          
        }
    }
}
