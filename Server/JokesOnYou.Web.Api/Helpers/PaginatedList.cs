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

        public static async Task<PaginatedList<T>> ToPaginatedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            List<T> items = await source.Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
