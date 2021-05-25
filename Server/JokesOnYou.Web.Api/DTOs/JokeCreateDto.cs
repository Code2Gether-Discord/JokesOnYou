namespace JokesOnYou.Web.Api.DTOs
{
    public class JokeCreateDto
    {
        public string Premise { get; set; }
        public string NormalizedPremise { get; set; }
        public string Punchline { get; set; }
        public string NormalizedPunchline { get; set; }
        public string UserId { get; set; }
    }
}
