using System;

namespace JokesOnYou.Web.Api.Models.Response
{
    public class TagReplyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string OwnerId { get; set; }
        public int Likes { get; set; }
    }
}
