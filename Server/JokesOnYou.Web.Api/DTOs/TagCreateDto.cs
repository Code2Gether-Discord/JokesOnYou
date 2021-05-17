using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    public class TagCreateDto
    {
        public string Name { get; set; }
        public int Likes { get; set; }
    }
}
