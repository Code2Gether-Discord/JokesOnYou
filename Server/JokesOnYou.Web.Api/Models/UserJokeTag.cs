using System;

namespace JokesOnYou.Web.Api.Models
{
    public class UserJokeTag
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int JokeId { get; set; }
        public int TagId { get; set; }
        public DateTime TaggedDate { get; set; } = DateTime.UtcNow;
        public int Likes { get; set; }
    }
}
