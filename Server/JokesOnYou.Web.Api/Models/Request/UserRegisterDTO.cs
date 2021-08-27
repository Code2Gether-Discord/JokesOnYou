using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
