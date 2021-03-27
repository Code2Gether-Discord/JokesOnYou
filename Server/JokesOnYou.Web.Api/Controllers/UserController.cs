using JokesOnYou.Web.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    public class UserController : ControllerBase
    {
        public ActionResult GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> GetUser([FromBody] string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult UpdateUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> DeleteUser([FromBody] string id)
        {
            throw new NotImplementedException();
        }
    }
}
