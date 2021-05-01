namespace JokesOnYou.Web.Api.Models
{
    public class Joke : BaseOwnedEntity
    {
        public string Premise { get; set; }
        public string Punchline { get; set; }
        public int TimesFlagged { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
