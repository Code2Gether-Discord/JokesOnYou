using System.Collections.Generic;

namespace JokesOnYou.Web.Api.Models
{
    public class Tag : BaseOwnedEntity
    {
        public string Name { get; set; }
        public List<Joke> Jokes { get; set; }
        public int Likes { get; set; }
    }
}
