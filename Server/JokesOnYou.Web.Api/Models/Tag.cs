using JokesOnYou.Web.Api.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class Tag
    {
        public int Id { get; set; }
        private string name;
        public string Name 
        { 
            get { return name; } 
            set
            {
                VerifyTag(value);
                name = value.FirstCharToUpperRestToLower();
            }
        }

        public static void VerifyTag(string name)
        {
            if (name.Any(c=> Char.IsWhiteSpace(c)))
            {
                throw new ArgumentException($"Error: Tag Given is not a valid Tag. \"{name}\". Tag should not Contain any special characters, numbers or spaces.");
            }
            if (name.Any(ch => !Char.IsLetter(ch)))
            {
                throw new ArgumentException($"Error: Tag Given is not a valid Tag. \"{name}\". Tag should not Contain any special characters, numbers or spaces.");
            }
        }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        [NotMapped]
        public ICollection<int> Jokes { get; set; } = new List<int>();
        public string OwnerId { get; set; }
        public int Likes { get; set; }
    }
}