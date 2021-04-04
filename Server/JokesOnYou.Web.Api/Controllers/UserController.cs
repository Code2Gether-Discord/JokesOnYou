using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly IUserService _userService;
        readonly ILogger<UserController> _logger;
        readonly IMapper _mapper;
        readonly ITokenService _tokenService;
        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper, ITokenService tokenService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _tokenService = tokenService;
        }

        //ok so returning user is dumb, since we return sensitive data, we need better DTO system, Valve plz fix
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReplyDTO>>> GetUsers()
        {
            return Ok(await _userService.GetAll());
        }

        //idk if its from body or Http get thing
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReplyDTO>> GetUserById(string id)
        {
            //Haha remove evil brackets
            if (id != ClaimsPrincipalExtension.GetUserId(User))
                return Unauthorized();

            var user = await _userService.GetUserReplyById(id);
            if (user != null)
            {
                return user;
            }
            _logger.LogInformation($"User not found; id: {id}");
            return NotFound();

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, UserUpdateDTO userUpdateDTO)
        {
            //Haha remove evil brackets
            if (id != ClaimsPrincipalExtension.GetUserId(User))
                return Unauthorized();

            var user = _mapper.Map<User>(userUpdateDTO);
            try
            {
                await _userService.UpdateUser(user);
                return NoContent();
            }
            catch (Exception)
            {
                _logger.LogInformation($"Something went wrong with updating user that had id {user.Id}");
                return NotFound();
            }

        }
        //Commented this just in case someone needs it ;)
        /*
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(UserLoginDTO userDto)
        {
            User user;
            if (string.IsNullOrWhiteSpace(userDto.Password))
            {
                return Unauthorized(); //or something else, idk
            }

            //maybe use a switch? should be much different
            if (!string.IsNullOrWhiteSpace(userDto.Username))
            {
                user =await _userService.Authenticate(userDto.Username, userDto.Password);
            }
            else if (!string.IsNullOrWhiteSpace(userDto.Email))
            {
                user =await _userService.Authenticate(userDto.Email, userDto.Password);
            }
            else
            {
                return Unauthorized();
            }

            if (user == null)
            {
                _logger.LogInformation($"User / possible attacker inserted wrong password on account id: {user.Id}");
                return Unauthorized();
            }
                

            _tokenService.GetToken(user);
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Token = _tokenService.GetToken(user)
        });
        }
        */
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            //Haha remove evil brackets
            if (id != ClaimsPrincipalExtension.GetUserId(User))
                return Unauthorized();

            
            await _userService.DeleteUser(id);
            return NoContent();

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserRegisterDTO userDto)
        {
            try
            {
                _userService.CreateUser(userDto);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                _logger.LogInformation($"Could not register user; reason: {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
