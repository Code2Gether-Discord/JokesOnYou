using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AllUsersDTO>>> GetAllUsers()
        {
            var allUsers = _userService.GetAll();
            return Ok(allUsers);
        }

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
