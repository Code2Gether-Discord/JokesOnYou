using System.Collections.Generic;

namespace JokesOnYou.Web.Api.Models.Interfaces
{
    public interface IFlaggable
    {
        public List<Flag> CurrentFlags { get; set; }
        public int TimesFlagged { get; set; }
    }
}
