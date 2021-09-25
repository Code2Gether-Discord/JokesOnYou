using JokesOnYou.Web.Api.Models.Interfaces;
using System;
using System.Linq.Expressions;

namespace JokesOnYou.Web.Api.Models.Filters
{
    public class AuthorFilter : IFilter
    {
        public string AuthorId { get; set; }
        public Expression<Func<Joke, bool>> Filter() => j => j.AuthorId == AuthorId;
    }
}
