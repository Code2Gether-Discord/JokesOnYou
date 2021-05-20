using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class Joke
    {
        public int Id { get; set; }
        [Required]
        public string Premise { get; set; }
        [Required]
        public string NormalizedPremise { get; set; }
        [Required]
        public string Punchline { get; set; }
        [Required]
        public string NormalizedPunchLine { get; set; }
        [Required]
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public int TimesFlagged { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
