using System;

namespace JokesOnYou.Web.Api.Models
{
    public class LikedJoke : BaseOwnedEntity
    {
        public Joke Joke { get; set; }
        public bool Liked { get; set; }
    }
}
