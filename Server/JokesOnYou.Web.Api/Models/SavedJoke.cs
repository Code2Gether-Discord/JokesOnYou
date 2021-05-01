namespace JokesOnYou.Web.Api.Models
{
    public class SavedJoke : BaseOwnedEntity
    {
        public Joke Joke { get; set; }
    }
}
