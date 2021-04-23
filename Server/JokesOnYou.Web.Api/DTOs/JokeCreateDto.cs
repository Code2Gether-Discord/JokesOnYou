using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class JokeCreateDto
    {
        public string Premise { get; set; }
        public string Punchline { get; set; }
        public string UserId { get; set; }
    }
}
