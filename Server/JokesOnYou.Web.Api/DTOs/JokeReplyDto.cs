using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class JokeReplyDto
    {
        public int Id { get; set; }
        public string Premise { get; set; }
        public string Punchline { get; set; }
        public JokeAuthorDto Author { get; set; }
        public DateTime UploadDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
