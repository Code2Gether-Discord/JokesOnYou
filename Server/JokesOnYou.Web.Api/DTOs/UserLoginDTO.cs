using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string LoginName { get; set; } //Can either be email or username
        [Required]
        public string Password { get; set; }
    }
}
