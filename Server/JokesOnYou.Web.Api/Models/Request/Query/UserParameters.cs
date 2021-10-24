using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request.Query
{
    public class UserParameters : PaginationParameters
    {
        public string SearchText { get; set; } = string.Empty;
    }
}
