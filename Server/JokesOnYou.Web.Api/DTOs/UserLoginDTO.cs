using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
    }
}
