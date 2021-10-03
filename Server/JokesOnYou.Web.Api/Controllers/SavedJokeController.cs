using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SavedJokeController : ControllerBase
    {
        private readonly ISavedJokeService _savedJokeService;

        public SavedJokeController(ISavedJokeService savedJokeService)
        {
            _savedJokeService = savedJokeService;
        }

        [HttpPost("{jokeId}")]
        public async Task<ActionResult> ToggleSavedJoke(int jokeId)
        {
            await _savedJokeService.ToggleSavedJoke(jokeId, ClaimsPrincipalExtension.GetUserId(User));
            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<JokeReplyDto>> GetSavedJokesByUserId()
        {
            var jokes = _savedJokeService.GetSavedJokesByUserId(ClaimsPrincipalExtension.GetUserId(User));
            return Ok(jokes);
        }
    }
}