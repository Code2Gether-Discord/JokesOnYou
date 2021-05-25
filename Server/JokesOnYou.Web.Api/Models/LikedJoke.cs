using System;

namespace JokesOnYou.Web.Api.Models
{
    public class LikedJoke
    {
        public int Id { get; set; }
        public int JokeId { get; set; }
        public bool Liked { get; set; }
        public DateTime LikeDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
    }
}
