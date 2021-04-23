using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class LikedTags
    {
        public int Id { get; set; }
        public int JokeId { get; set; }
        public DateTime SavedDate { get; set; } = DateTime.Now;
        public List<int> Tags { get; set; }
        public string UserId { get; set; }
    }
}
