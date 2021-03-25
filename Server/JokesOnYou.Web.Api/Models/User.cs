using System;

namespace JokesOnYou.Web.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime SignUpDate { get; set; }
        public string Role { get; set; }
        public int Strikes { get; set; }
        public bool Nsfw { get; set; }
    }
}
