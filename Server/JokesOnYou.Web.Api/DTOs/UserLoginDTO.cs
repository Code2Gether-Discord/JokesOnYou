using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class UserLoginDTO
    {
        //need to make it so that either email xor username are required, maybe just make 1 variable that can either be one of those like Max suggested?
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
