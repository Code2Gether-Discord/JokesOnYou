using System;
using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class ReasonCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required, Range(1, 50)]
        public int Severity { get; set; }
    }
}
