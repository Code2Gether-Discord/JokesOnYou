using System;
using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.Models
{
    public class Reason
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Range(1, 5)]
        public int Severity { get; set; }
    }
}