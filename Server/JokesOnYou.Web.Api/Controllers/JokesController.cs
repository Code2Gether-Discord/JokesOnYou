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
    public class JokesController : ControllerBase
    {
        private readonly IJokesService _jokesService;

        public JokesController(IJokesService jokesService)
        {
            _jokesService = jokesService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JokeReplyDto>>> GetAllJokesAsync()
        {
            var jokeDtos = await _jokesService.GetAllJokeDtosAsync();
            return Ok(jokeDtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<JokeReplyDto> GetJokeById(int id)
        {
            var jokeReplyDto = await _jokesService.GetJokeReplyById(id);
            return jokeReplyDto;
        }

        [HttpPut]
        public async Task<ActionResult<JokeUpdateDto>> UpdateJoke(JokeUpdateDto jokeUpdateDto)
        {
            await _jokesService.UpdateJoke(jokeUpdateDto);
            return NoContent();
        }
    }
}
