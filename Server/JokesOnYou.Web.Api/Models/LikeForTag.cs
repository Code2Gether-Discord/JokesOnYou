using System;
using System.Collections.Generic;

namespace JokesOnYou.Web.Api.Models
{
    public class LikeForTag
    {
        public int Id { get; set; }
        public int UserJokeTagId { get; set; }
        public string UserId { get; set; }
        public DateTime SavedDate { get; set; } = DateTime.UtcNow;
    }
}
