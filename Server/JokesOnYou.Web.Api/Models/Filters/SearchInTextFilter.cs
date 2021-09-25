using JokesOnYou.Web.Api.Models.Interfaces;
using System;
using System.Linq.Expressions;

namespace JokesOnYou.Web.Api.Models.Filters
{
    public class SearchInTextFilter : IFilter
    {
        public string Text { get; set; }

        public Expression<Func<Joke, bool>> Filter() => j => j.NormalizedPremise.Contains(Text.ToUpper()) || j.NormalizedPunchLine.Contains(Text.ToUpper());
    }
}
