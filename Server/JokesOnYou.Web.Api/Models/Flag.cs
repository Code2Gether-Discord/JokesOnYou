using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class Flag
    {
        public string Id { get; set; }
        public Reason Reason { get; set; }
        public User Issuer { get; set; }
        public DateTime Created { get; set; }
    }
}
