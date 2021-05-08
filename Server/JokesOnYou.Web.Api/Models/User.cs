using Microsoft.AspNetCore.Identity;
using System;

namespace JokesOnYou.Web.Api.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime SignUpDate { get; set; } = DateTime.Now;
        public string Role { get; set; }
        public int Strikes { get; set; }
        public bool Nsfw { get; set; }
    }
}
