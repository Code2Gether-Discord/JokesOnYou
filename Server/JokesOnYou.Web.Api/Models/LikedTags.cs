using System;
using System.Collections.Generic;

namespace JokesOnYou.Web.Api.Models
{
    public class LikedTags
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public string UserId { get; set; }
        public DateTime SavedDate { get; set; } = DateTime.UtcNow;
    }
}
