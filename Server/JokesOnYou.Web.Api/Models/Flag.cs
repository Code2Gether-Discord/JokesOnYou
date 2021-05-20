using JokesOnYou.Web.Api.Models.Interfaces;
using System;

namespace JokesOnYou.Web.Api.Models
{
    public class Flag
    {
        public int Id { get; set; }
        public Reason Reason { get; set; }
        public string IssuerId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public IFlaggable Flagged { get; set; }
    }
}
