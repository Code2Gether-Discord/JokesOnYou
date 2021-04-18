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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _ITokenService;
        private readonly IUserRepository _IUserRepository;
        private readonly IUserService _IUserService; 

        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            ITokenService ITokenService,
            IUserRepository IUserRepository,
            IUserService IUserService
            )
        { 
            _userManager = userManager;
            _signInManager = signInManager;
            _ITokenService = ITokenService;
            _IUserRepository = IUserRepository;
            _IUserService = IUserService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login (UserLoginDTO userLogin)
        {
            var loginResult = await _IUserService.LoginUser(userLogin);
            return Ok(loginResult); 
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDTO userRegister)
        {
            var result = await _IUserRepository.CreateUserAsync(userRegister);
            return Ok(result);
        }
    }
}
