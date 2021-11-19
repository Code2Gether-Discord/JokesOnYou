using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class TagCreateDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Tag name cannot be larger than 20 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Name { get; set; }
    }
}
