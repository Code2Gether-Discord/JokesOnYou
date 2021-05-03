using JokesOnYou.Web.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Services.Interfaces;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Repositories.Interfaces;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserReplyDTO>> Login (UserLoginDTO userLogin)
        {
            var userReplyDTO = await _userService.LoginUser(userLogin);
            return userReplyDTO;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDTO userRegister)
        {
            await _userService.RegisterUser(userRegister);
            return Ok();
        }
    }
}
