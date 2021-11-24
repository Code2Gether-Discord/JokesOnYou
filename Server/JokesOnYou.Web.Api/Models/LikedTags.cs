using System;
using System.Collections.Generic;

namespace JokesOnYou.Web.Api.Models
{
    public class LikedTags
    {
        public int Id { get; set; }
        public int JokeId { get; set; }
        public DateTime SavedDate { get; set; } = DateTime.UtcNow;
        public ICollection<int> Tags { get; set; } = new List<int>();
        public string UserId { get; set; }
    }
}
