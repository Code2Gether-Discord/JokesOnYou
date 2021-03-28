using JokesOnYou.Web.Api.DTOs;
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
        [HttpGet]
        [Authorize(Roles = "Registered")]
        public ActionResult GetUsers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "NOROLE")]
        public Task<ActionResult> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public ActionResult UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
