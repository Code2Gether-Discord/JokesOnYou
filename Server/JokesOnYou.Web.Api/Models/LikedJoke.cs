using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class LikedJoke
    {
        public int Id { get; set; }
        public Joke Joke { get; set; }
        public bool Liked { get; set; }
        public DateTime LikeDate { get; } = DateTime.Now;
        public User User { get; set; }
    }
}
