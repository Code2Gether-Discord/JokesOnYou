using System;

namespace JokesOnYou.Web.Api.Models.Response
{
    public class JokeReplyDto
    {
        public int Id { get; set; }
        public string Premise { get; set; }
        public string Punchline { get; set; }
        public string AuthorId { get; set; }
        public DateTime UploadDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
