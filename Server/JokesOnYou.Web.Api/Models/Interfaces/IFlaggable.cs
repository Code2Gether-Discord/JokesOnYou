using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Interfaces
{
    public interface IFlaggable
    {
        public List<Flag> CurrentFlags { get; set; }
        public int TimesFlagged { get; set; }
    }
}
