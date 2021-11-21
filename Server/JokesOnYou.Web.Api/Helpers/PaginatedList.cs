using JokesOnYou.Web.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int? PrevousPage { get; set; }
        public int? NextPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int ItemsCount { get; set; }

        public PaginatedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            if (TotalPages >= CurrentPage)
            {
                PrevousPage = CurrentPage - 1 >= 1 ? CurrentPage - 1 : null;
                NextPage = CurrentPage + 1 <= TotalPages ? CurrentPage + 1 : null;
            }

            PageSize = pageSize;
            ItemsCount = count;

            AddRange(items);
        }

        /// <summary>
        /// Creates a new PaginatedList after paginating and executing the query <see cref="QueryableExtensions.PaginateAsync{T}(IQueryable{T}, int, int)"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>A <see cref="PaginatedList{T}"/> containing the result of the query</returns>
        public static async Task<PaginatedList<T>> ToPaginatedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var (query, count) = await source.PaginateAsync(pageNumber, pageSize);
            var items = await query.ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
