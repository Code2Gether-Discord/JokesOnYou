using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JokesController : ControllerBase
    {
        private readonly IJokesService _jokesService;

        public JokesController(IJokesService jokesService)
        {
            _jokesService = jokesService;
        }

        [Authorize(Roles = "Registered,Admin")]
        [HttpPost]
        public async Task<ActionResult<JokeReplyDto>> CreateJokeAsync(JokeDto jokeDto)
        {

            var userId = ClaimsPrincipalExtension.GetUserId(User);
            var jokeReplyDto = await _jokesService.CreateJokeAsync(jokeDto, userId);

            return jokeReplyDto;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JokeReplyDto>>> GetAllJokesAsync([FromQuery]JokesFilterDto jokesFilter)
        {
            var jokeDtos = await _jokesService.GetFilteredJokeDtosAsync(jokesFilter);
            return Ok(jokeDtos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJoke(int id)
        {
            await _jokesService.RemoveJokeAsync(id);
            return NoContent();
        }
        
        [HttpPut]
        public async Task<ActionResult<JokeReplyDto>> UpdateJoke(JokeUpdateDto jokeUpdateDto)
        {
            var jokeDto = await _jokesService.UpdateJoke(jokeUpdateDto);
            return jokeDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<JokeReplyDto>> GetJoke(int id)
        {
            var joke = await _jokesService.GetJokeDtoAsync(id);
            return joke;
        }

    }
}
