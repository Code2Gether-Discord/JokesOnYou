namespace JokesOnYou.Web.Api.Models.Request
{
    public class UserUpdateDTO
    {
        public string Id { get; set; }
        public bool Nsfw { get; set; } //Unsure if this means that the user posted nsfw or just that the user wants to see nsfw
    }
}
