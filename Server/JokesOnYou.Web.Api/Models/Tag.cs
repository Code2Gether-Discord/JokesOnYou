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
        public string Name { get; set; }
        public DateTime Created { get; set;  } = DateTime.Now;
        [NotMapped]
        public ICollection<int> Jokes { get; set; } = new List<int>();
        public string OwnerId { get; set; }
        public int Likes { get; set; }
    }
}
