using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string Premise { get; set; }
        public string Punchline { get; set; }
        public User Author { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public int TimesFlagged { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
