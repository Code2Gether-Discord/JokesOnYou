using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
