using JokesOnYou.Web.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    public class AuthController
    {
        public ActionResult Login([FromBody] UserLoginDTO userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Register([FromBody] UserRegisterDTO userRegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}
