using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<UserReplyDTO> Login(UserLoginDTO userLoginDto)
        {
            try
            {
                var userDto = await _authService.LoginAsync(userLoginDto);
                return Ok(userDto);
            }
            catch (UserLoginException ex)
            {
                return Unauthorized(ex.Message);
            }
            /*
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message);
            }*/
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDto)
        {
            
        }
    }
}
