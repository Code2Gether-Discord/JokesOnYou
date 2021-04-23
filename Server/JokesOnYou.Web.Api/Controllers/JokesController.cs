using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Extensions;
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
    public class JokesController : ControllerBase
    {
        private readonly IJokesService _jokesService;

        public JokesController(IJokesService jokesService)
        {
            _jokesService = jokesService;
        }

        [Authorize(Roles = "Registered,Admin")]
        [HttpPost]
        public async Task<ActionResult<JokeReplyDto>> CreateJokeAsync(JokeCreateDto jokeCreateDto)
        {

            jokeCreateDto.UserId = ClaimsPrincipalExtension.GetUserId(User);
            var jokeReplyDto = await _jokesService.CreateJokeAsync(jokeCreateDto);

            return Ok(jokeReplyDto);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JokeReplyDto>>> GetAllJokesAsync()
        {
            var jokeDtos = await _jokesService.GetAllJokeDtosAsync();
            return Ok(jokeDtos);
        }

    }
}
