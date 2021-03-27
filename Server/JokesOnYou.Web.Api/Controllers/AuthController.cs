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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDto)
        {
            try
            {
                var user = await _authService.LoginAsync(userLoginDto);
                return Ok(user);
            }
            catch (UserLoginException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDTO userRegisterDto)
        {
            try
            {
                var user = _authService.Register(userRegisterDto);
                return Ok(user);
            }
            catch (UserRegisterException ex)
            {
                return BadRequest(ex.Message);
            }
            

            
        }
    }
}
