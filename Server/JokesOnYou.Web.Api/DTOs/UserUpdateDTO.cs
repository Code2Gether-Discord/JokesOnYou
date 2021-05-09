using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class UserUpdateDTO
    {
        public string Name { get; set; } //Make sure that name is unique
        public string Role { get; set; }
        public bool Nsfw { get; set; } //Unsure if this means that the user posted nsfw or just that the user wants to see nsfw

    }
}
