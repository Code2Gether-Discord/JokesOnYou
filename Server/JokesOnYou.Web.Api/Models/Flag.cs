using JokesOnYou.Web.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class Flag : BaseOwnedEntity
    {
        public Reason Reason { get; set; }
        public IFlaggable Flagged { get; set; }
    }
}
