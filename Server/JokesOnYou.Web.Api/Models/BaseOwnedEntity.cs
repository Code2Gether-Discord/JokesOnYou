using System;

namespace JokesOnYou.Web.Api.Models
{
    public abstract class BaseOwnedEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int OwnerId { get; set; }      
    }
}
