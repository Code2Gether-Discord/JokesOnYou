using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    // Does not update joke's id, likes, author, uploaddate, or dislikes. Just Premise and Punchline
    public class JokeUpdateDTO
    {
        public string Premise { get; set; }
        public string Punchline { get; set; }
    }
}
