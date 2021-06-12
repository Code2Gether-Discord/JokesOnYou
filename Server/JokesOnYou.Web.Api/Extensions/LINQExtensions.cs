using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class LINQExtensions
    {
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, bool value)
            => value ? source.Where(predicate) : source;
    }
}
