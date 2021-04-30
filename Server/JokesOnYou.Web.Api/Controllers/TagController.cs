using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTag(TagCreateDto tag)
        {
            if (tag == null) return Problem("There is no declared tag");

            var result = await _tagService.DeleteTag(tag);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTag(List<TagCreateDto> tags)
        {
            if (tags == null) return Problem("There is no declared tags");

            var result = await _tagService.DeleteMultipleTag(tags);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTag(int? tagId)
        {
            if (tagId == null) return Problem("There is no declared tagId");

            var result = await _tagService.DeleteTag(tagId.Value);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTag(int[] tagIds)
        {
            if (tagIds == null) return Problem("There is no declared tagIds");

            var result = await _tagService.DeleteMultipleTag(tagIds);
            return Ok(result);
        }
    }
}
