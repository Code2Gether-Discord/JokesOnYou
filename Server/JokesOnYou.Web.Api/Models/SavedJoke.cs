using System;
using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.Models
{
    public class SavedJoke
    {
        public int Id { get; set; }
        [Required]
        public int JokeId { get; set; }
        public DateTime SavedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string UserId { get; set; }
    }
}
