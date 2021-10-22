using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request.Query
{
    public class UserPaginationQueryParameters : PaginationQuery
    {
        public string SearchText { get; set; } = string.Empty;
    }
}
