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
        public int PageSize { get; set; }
        public int NextPage { get; set; }
        public int PrevousPage { get; set; }
        public int PageNumber { get; set; }
        public PaginatedList(List<T> items, int pageNumber, int pageSize)
        {
            PageSize = pageSize;
            CurrentPage = pageNumber;

            AddRange(items);
        }

        public static async Task<PaginatedList<T>> ToPaginatedList(IQueryable<T> source, int pageNumber, int pageSize, Expression<Func<T,bool>> expression)
        {
            if (expression != null)
            {
                source = source.Where(expression);
            }

            List<T> items = await source.Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

            return new PaginatedList<T>(items, pageNumber, pageSize);
        }
    }
}
