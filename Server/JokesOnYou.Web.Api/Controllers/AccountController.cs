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
using JokesOnYou.Web.Api.Areas.Identity.Data;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Services;
using JokesOnYou.Web.Api.DTOs;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private DataContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        // private readonly 

        public AccountController(DataContext dbContext, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        { 
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("getToken")]
        public async Task<ActionResult> GetToken(UserLoginDTO userLogin)
        {
            // If user has registered
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == userLogin.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (signInResult.Succeeded)
                {
                    string token = returnTokenString();
                    string userName = user.Name;
                    string statement = userName + "'s token is " + token;
                    return Ok(statement);
                }
                else
                {
                    return Ok("failed, try again"); 
                }
            }

            // If user has not registered. Also could be used for guests
            var myUser = new User {
                Name = "first user",
                SignUpDate = DateTime.Now,
                Role = "not an admin",
                Strikes = 0,
            };

            // await AuthService.RegisterAsy

            await _userManager.CreateAsync(myUser, "Password123.");
            if (userLogin.Email == myUser.Name)
            {
                string tokenString = returnTokenString();
                string statement = "created user's token is " + tokenString; 
                return Ok(statement);
            }
            else
            {
                return Unauthorized("try again!");
            }

            string returnTokenString()
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("SECRETThedefaultimplementationofIdentityUser<TKey>whichusesastringasaprimarykey.");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userLogin.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDTO userRegister)
        {
            User myUser = new User()
            {
                Email = userRegister.Email,
                UserName = userRegister.Email,
                EmailConfirmed = false,
                Nsfw = false,
            };

            var result = await _userManager.CreateAsync(myUser, userRegister.Password);

            if (result.Succeeded)
            {
                return Ok(new { Result = "Reigster Success" });
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.Append(error.Description);
                    stringBuilder.Append("\r\n");
                }
                return Ok(new { Result = $"Register Fail: {stringBuilder.ToString()}" });
            }
        }
    }
}
