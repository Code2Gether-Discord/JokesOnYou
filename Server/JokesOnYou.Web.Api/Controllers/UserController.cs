using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Disable "this async method lacks an await operator" Remove this when we actually implement methods
        #pragma warning disable 1998

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
