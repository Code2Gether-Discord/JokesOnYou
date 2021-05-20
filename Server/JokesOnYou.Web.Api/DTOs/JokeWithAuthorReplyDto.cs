using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class JokeWithAuthorReplyDto : JokeReplyDto
    {
        public string AuthorName { get; set; }
    }
}
