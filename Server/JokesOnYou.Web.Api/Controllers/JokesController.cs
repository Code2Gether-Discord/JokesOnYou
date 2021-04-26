using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JokesOnYou.Web.Api.Models;

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

        // Create the whole line for Update Joke API call.
        // UpdateJoke inside controller HTTP put
        // UpdateJoke inside JokeService
        // UpdateJoke inside JokeRepository
        // Use AutoMapper if you can.

        [HttpPatch]
        [AllowAnonymous]
        public async Task<ActionResult<JokeUpdateDTO>> UpdateJoke(JokeUpdateDTO jokeUpdateDTO)
        {
            await _jokesService.UpdateJoke(jokeUpdateDTO);
            return Ok(); 
        }
    }
}
