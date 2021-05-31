using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.DTOs
{
    public class TagCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
