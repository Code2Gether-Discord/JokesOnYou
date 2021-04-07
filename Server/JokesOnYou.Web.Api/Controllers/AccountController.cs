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
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _ITokenService;
        private readonly IUserRepository _IUserRepository;

        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            ITokenService ITokenService,
            IUserRepository IUserRepository
            )
        { 
            _userManager = userManager;
            _signInManager = signInManager;
            _ITokenService = ITokenService;
            _IUserRepository = IUserRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login (UserLoginDTO userLogin)
        {
            // If user has registered
            var user = await _IUserRepository.GetUserByEmail(userLogin.Email);

            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (signInResult.Succeeded)
                {
                    var myUserReplyDTO = new UserReplyDTO() { 
                        Id = user.Id, 
                        Email = user.Email, 
                        UserName = user.Email, 
                        Role = "not admin.", 
                        Token = _ITokenService.GetToken(user) 
                    };
                    return Ok(myUserReplyDTO);
                }
                else
                {
                    return Ok("Password does not match"); 
                }
            }

            // If user has not registered. Also could be used for guests
            var myUser = new User {
                Name = "first user",
                SignUpDate = DateTime.Now,
                Role = "not an admin",
                Strikes = 0,
            };

            await _userManager.CreateAsync(myUser, "Password123.");
            if (userLogin.Email == myUser.Name)
            {
                string tokenString = _ITokenService.GetToken(myUser);
                string statement = "CREATED USER's token is " + tokenString; 
                return Ok(statement);
            }
            else
            {
                return Unauthorized("Sorry, we could not find an account with that email");
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDTO userRegister)
        {
            var result = await _IUserRepository.CreateUserAsync(userRegister);
            return Ok(result);
        }
    }
}
