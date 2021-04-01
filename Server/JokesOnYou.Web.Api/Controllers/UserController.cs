using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
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
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetAll());
        }

        //idk if its from body or Http get thing
        [HttpGet("{id}")]
        public  ActionResult<User> GetUserById(string id)
        {
            var user =  _userService.GetUserById(id);

            if (user != null)
            {
                return user;
            }
            _logger.LogInformation($"User not found; id: {id}");
            return NotFound();
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, [FromBody]UserUpdateDTO userUpdateDTO)
        {
            var user = _mapper.Map<User>(userUpdateDTO);


            if (await _userService.UpdateUser(user))
            {
                return Ok();
            }
            _logger.LogInformation($"Something went wrong with updating user that had id {user.Id}");

            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] UserLoginDTO userDto)
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
        
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                _logger.LogInformation($"Could not delete user id: {user.Id}");
                return NotFound();
            }
            _userService.DeleteUser(id);
            return Ok();

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register([FromBody] UserRegisterDTO userDto)
        {

            try
            {
                // save 
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
