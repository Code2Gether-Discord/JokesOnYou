using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class LikedTags
    {
        public int Id { get; set; }
        public Joke Joke { get; set; }
        public DateTime SavedDate { get; set; }
        public User User { get; set; }
    }
}
