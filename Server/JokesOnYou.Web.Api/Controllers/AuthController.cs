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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDto)
        {
            var user = _authService.Login(userLoginDto);

            if(User == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            else
            {
                return Ok(user);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            
        }
    }
}
