using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Extensions;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly ILogger _logger;

        public TagController(ITagService tagService, ILogger<TagController> logger)
        {
            _tagService = tagService;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _tagService.GetTagAsync(id);
            string userId = User.Identity.Name;
            if (tag.OwnerId == userId || User.IsInRole("Admin"))
            {
                await _tagService.DeleteTagAsync(tag);
                return NoContent();
            }
            else
            {
                return Unauthorized("Not the Owner or an admin.");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagReplyDto>>> GetAllTagsAsync()
        {
            var tagDtos = await _tagService.GetAllTagDtosAsync();
            return Ok(tagDtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<TagReplyDto>> GetTag(int id)
        {
            var tagDto = await _tagService.GetTagDtoAsync(id);
            return tagDto;
        }
        
        [Authorize(Roles = "Registered,Admin")]
        [HttpPost]
        public async Task<ActionResult<TagReplyDto>> CreateTagAsync(TagCreateDto tagCreateDto)
        {
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            var tagReplyDto = await _tagService.CreateTagAsync(tagCreateDto, userId); 
            return tagReplyDto;
        }
    }
}