using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JokesOnYou.Web.Api.Models
{
    public class User : IdentityUser
    {
        public DateTime SignUpDate { get; set; } = DateTime.Now;
        public string Role { get; set; }
        public int Strikes { get; set; }
        public bool Nsfw { get; set; }
        public List<int> TagIds { get; set; }
    }
}
