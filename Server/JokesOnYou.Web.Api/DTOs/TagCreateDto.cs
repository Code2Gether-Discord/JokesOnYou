using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.DTOs
{
    public class TagCreateDto
    {
        [Required()]
        public string Name { get; set; }
    }
}
