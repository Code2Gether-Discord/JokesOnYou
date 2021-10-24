using JokesOnYou.Web.Api.Models.Request.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class JokesFilterDto : PaginationParameters
    {
        public string AuthorId { get; set; }
        public int MinimumLikes { get; set; } = int.MinValue;
        public int MaximumLikes { get; set; } = int.MaxValue;
        public DateTime MinimumDate { get; set; } = DateTime.MinValue;
        public DateTime MaximumDate { get; set; } = DateTime.MaxValue;
        public string SearchText { get; set; } = string.Empty;
    }
}
