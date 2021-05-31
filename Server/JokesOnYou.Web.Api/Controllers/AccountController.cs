using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult<UserReplyDTO>> Login(UserLoginDTO userLogin)
        {
            var userReplyDTO = await _userService.LoginUser(userLogin);
            return userReplyDTO;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDTO userRegister)
        {
            await _userService.RegisterUser(userRegister);
            return NoContent();
        }
    }
}