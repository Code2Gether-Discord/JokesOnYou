using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReplyDTO>>> GetUsers()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReplyDTO>> GetUserById(string id)
        {


            var user = await _userService.GetUserReplyById(id);

            if (user != null) return user;

            _logger.LogInformation($"User not found; id: {id}");
            return NotFound();

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, UserUpdateDTO userUpdateDTO)
        {
            if (id != ClaimsPrincipalExtension.GetUserId(User))
            {
                return Unauthorized();
            }

            await _userService.UpdateUser(userUpdateDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            if (id != ClaimsPrincipalExtension.GetUserId(User))
            {
                return Unauthorized();
            }


            await _userService.DeleteUser(id);
            return NoContent();

        }

    }
}
