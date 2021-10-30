using System;
using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool NsfwEnabled { get; set; } = false;

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
