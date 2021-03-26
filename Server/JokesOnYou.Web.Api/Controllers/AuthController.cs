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
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login(UserLoginDTO userLoginDto)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public Task<ActionResult> Register(UserRegisterDTO userRegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}
