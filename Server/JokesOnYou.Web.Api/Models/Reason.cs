using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class Reason
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Severity { get; set; }
    }
}
