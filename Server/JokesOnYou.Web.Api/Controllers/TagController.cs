using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using JokesOnYou.Web.Api.DTOs;

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

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagReplyDto>>> GetAllTagsAsync()
        {
            var tagDtos = await _tagService.GetAllTagDtosAsync();
            return Ok(tagDtos);
        }

        [Authorize(Roles = "Registered,Admin")]
        [HttpPost]
        public async Task<ActionResult<TagReplyDto>> CreateTagAsync(TagCreateDto tagCreateDto)
        {
            var tagReplyDto = await _tagService.CreateTagAsync(tagCreateDto); 
            return tagReplyDto;
        }
    }
}
