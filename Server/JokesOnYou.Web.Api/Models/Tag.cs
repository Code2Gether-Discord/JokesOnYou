using JokesOnYou.Web.Api.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                name = ti.ToTitleCase(value);
            }
        }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        [NotMapped]
        public ICollection<int> Jokes { get; set; } = new List<int>();
        public string OwnerId { get; set; }
        public int Likes { get; set; }
    }
}