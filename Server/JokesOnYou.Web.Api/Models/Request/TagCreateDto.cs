using System.ComponentModel.DataAnnotations;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class TagCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
