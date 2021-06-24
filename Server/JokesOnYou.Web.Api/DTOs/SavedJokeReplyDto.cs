using System;

namespace JokesOnYou.Web.Api.DTOs
{
    public class SavedJokeReplyDto
    {
        public int JokeId { get; set; }
        public DateTime SavedDate { get; set; }
    }
}
