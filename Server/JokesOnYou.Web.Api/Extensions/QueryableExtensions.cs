using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        ///  Gets the total amount of items in the database and then applies pagination to the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>The query paginated and the count before pagination was applied</returns>
        public static async Task<(IQueryable<T> query, int count)> PaginateAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();

            var query = source.Skip(pageSize * (pageNumber - 1))
            .Take(pageSize);

            return (query, count);
        }
    }
}
