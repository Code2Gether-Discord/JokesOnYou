using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.DTOs
{
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; } //Can either be email or username
        [Required]
        public string Password { get; set; }
    }
}
