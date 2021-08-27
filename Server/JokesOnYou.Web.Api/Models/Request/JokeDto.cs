using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class JokeDto
    {
        public string Premise { get; set; }
        public string Punchline { get; set; }
    }
}
