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
        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
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
            _logger.LogInformation($"customer {id} not found");
            return NotFound();
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, UserUpdateDTO userUpdateDTO)
        {
            var user = _mapper.Map<User>(userUpdateDTO);


            if (await _userService.UpdateUser(user))
            {
                return Ok();
            }

            
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLoginDTO userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }



        /*
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.Id = id;
 
            try
            {
                // save 
                _userService.Update(user, userDto.Password);
                return Ok();
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }*/
        [HttpDelete]
        public ActionResult DeleteUser([FromBody] string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(id);
            return Ok();

        }
    }
}
