using JokesOnYou.Web.Api.Models.Interfaces;
using System;
using System.Linq.Expressions;

namespace JokesOnYou.Web.Api.Models.Filters
{
    public class LikesFilter : IFilter
    {
        public int Minimum { get; set; } = int.MinValue;
        public int Maximum { get; set; } = int.MaxValue;
        public Expression<Func<Joke, bool>> Filter() => j => j.Likes >= Minimum && j.Likes <= Maximum;
    }
}
