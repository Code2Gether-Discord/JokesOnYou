using System;
using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.DTOs
{
    public class ReasonCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required, Range(1, 5)]
        public int Severity { get; set; }
    }
}
